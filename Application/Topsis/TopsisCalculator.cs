using Application.Abstractions;
using Application.Abstractions.Lineup;
using Application.Abstractions.Topsis;
using Domain.Entities;

namespace Application.Topsis
{
    public class TopsisCalculator : ITopsisCalculator
    {
        private IReadOnlyCollection<ActionType> actionTypes = new List<ActionType>();

        private readonly IUnitOfWork unitOfWork;
        private readonly IEstimationNormalizer estimationNormalizer;
        private readonly ICriteriaWeightNormalizer criteriaWeightNormalizer;
        private readonly IWeightedScoresCalculator weightedScoresCalculator;

        public TopsisCalculator(
            IUnitOfWork unitOfWork, 
            IEstimationNormalizer estimationNormalizer, 
            ICriteriaWeightNormalizer criteriaWeightNormalizer, 
            IWeightedScoresCalculator weightedScoresCalculator)
        {
            this.unitOfWork = unitOfWork;
            this.estimationNormalizer = estimationNormalizer;
            this.criteriaWeightNormalizer = criteriaWeightNormalizer;
            this.weightedScoresCalculator = weightedScoresCalculator;
        }

        public async Task<Dictionary<Player, double>> CalculateBestPlayers(
            IReadOnlyCollection<Player> players,
            Position position,
            IReadOnlyCollection<Training> trainings)
        {
            actionTypes = await unitOfWork.ActionTypeRepository.GetAsync();
            var playerScores = InitializePlayerScores(players, position, trainings);

            if (playerScores.Count == 0)
            {
                return null;
            }

            if (playerScores.Count == 1)
            {
                return new Dictionary<Player, double>()
                {
                    { playerScores.First().Key, 1 }
                };
            }

            await IncludePlayerActions(position, playerScores);

            var normalizedPlayerScores = estimationNormalizer.NormalizeScores(playerScores);
            var normalizedCriteriaWeights = criteriaWeightNormalizer.NormalizeWeights(position);
            var weightedNormalizedPlayerScores = weightedScoresCalculator.CalculateWeightedScores(normalizedPlayerScores, normalizedCriteriaWeights);

            return ApplyTOPSIS(weightedNormalizedPlayerScores);
        }

        private Dictionary<Player, Dictionary<Criterion, float>> InitializePlayerScores(
            IReadOnlyCollection<Player> players,
            Position position,
            IReadOnlyCollection<Training> trainings)
        {
            var scores = new Dictionary<Player, Dictionary<Criterion, float>>();
            foreach (var player in players)
            {
                var playerMarks = new Dictionary<Criterion, float>();
                foreach (var criterion in position.Criteria.Where(x => !actionTypes.Any(action => action.Name == x.Name)))
                {
                    var marks = player.TrainingRecords
                        .Where(tr => trainings.Select(t => t.Id).Contains(tr.TrainingId))
                        .SelectMany(tr => tr.TrainingMarks)
                        .Where(tm => tm.CriterionId == criterion.Id)
                        .Select(tm => tm.Mark)
                        .ToList();

                    if (marks.Count > 0)
                    {
                        playerMarks[criterion] = marks.Average();
                    }
                }

                if (playerMarks.Count == position.Criteria.Where(x => !actionTypes.Any(action => action.Name == x.Name)).Count()
                    && playerMarks.Values.All(x => x > 0))
                {
                    scores[player] = playerMarks;
                }
            }
            return scores;
        }

        private async Task IncludePlayerActions(Position position, Dictionary<Player, Dictionary<Criterion, float>> playerScores)
        {
            foreach (var player in playerScores.Keys)
            {
                foreach (var criterion in position.Criteria.Where(x => actionTypes.Any(action => action.Name == x.Name)))
                {
                    var actionType = (await unitOfWork.ActionTypeRepository.GetAsync(x => x.Name == criterion.Name)).FirstOrDefault();

                    if (actionType != null)
                    {
                        var playerActions = player.MatchPlayerActions.Where(x => x.ActionType.Name == actionType.Name).ToList();
                        var numberOfMatches = playerActions.Select(x => x.MatchId).Distinct().Count();

                        int actionPerMatch = numberOfMatches != 0 ? playerActions.Sum(a => a.ActionNumber) / numberOfMatches : 0;

                        playerScores[player][criterion] = actionPerMatch;
                    }
                }
            }
        }

        public static Dictionary<Player, double> ApplyTOPSIS(Dictionary<Player, Dictionary<Criterion, float>> weightedNormalizedPlayerScores)
        {
            // Determine the ideal and negative-ideal solutions
            var idealSolution = new Dictionary<Criterion, float>();
            var negativeIdealSolution = new Dictionary<Criterion, float>();

            foreach (var criterion in weightedNormalizedPlayerScores.First().Value.Keys)
            {
                var values = weightedNormalizedPlayerScores.Select(p => p.Value[criterion]).ToList();

                idealSolution[criterion] = values.Max();
                negativeIdealSolution[criterion] = values.Min();
            }

            // Calculate the Euclidean distances to the ideal and negative-ideal solutions
            var distanceToIdeal = new Dictionary<Player, double>();
            var distanceToNegativeIdeal = new Dictionary<Player, double>();

            foreach (var playerScores in weightedNormalizedPlayerScores)
            {
                double sumOfSquaresToIdeal = 0;
                double sumOfSquaresToNegativeIdeal = 0;

                foreach (var score in playerScores.Value)
                {
                    sumOfSquaresToIdeal += Math.Pow(score.Value - idealSolution[score.Key], 2);
                    sumOfSquaresToNegativeIdeal += Math.Pow(score.Value - negativeIdealSolution[score.Key], 2);
                }

                distanceToIdeal[playerScores.Key] = Math.Sqrt(sumOfSquaresToIdeal);
                distanceToNegativeIdeal[playerScores.Key] = Math.Sqrt(sumOfSquaresToNegativeIdeal);
            }

            // Calculate TOPSIS scores (similarity to the worst alternative)
            var topsisScores = new Dictionary<Player, double>();
            foreach (var player in weightedNormalizedPlayerScores.Keys)
            {
                var similarity = distanceToNegativeIdeal[player] / (distanceToIdeal[player] + distanceToNegativeIdeal[player]);
                topsisScores[player] = similarity;
            }

            // Rank the alternatives
            var rankedPlayers = topsisScores.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            return rankedPlayers;
        }
    }
}
