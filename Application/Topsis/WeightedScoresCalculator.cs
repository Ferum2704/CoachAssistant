using Application.Abstractions.Topsis;
using Domain.Entities;

namespace Application.Topsis
{
    public class WeightedScoresCalculator : IWeightedScoresCalculator
    {
        public Dictionary<Player, Dictionary<Criterion, float>> CalculateWeightedScores(Dictionary<Player, Dictionary<Criterion, float>> normalizedPlayerScores, Dictionary<Criterion, float> normalizedCriteriaWeights)
        {
            var weightedPlayerScores = new Dictionary<Player, Dictionary<Criterion, float>>();

            foreach (var playerScore in normalizedPlayerScores)
            {
                var weightedScores = new Dictionary<Criterion, float>();
                foreach (var score in playerScore.Value)
                {
                    Criterion criterion = score.Key;
                    float normalizedScore = score.Value;

                    if (normalizedCriteriaWeights.TryGetValue(criterion, out float weight))
                    {
                        weightedScores[criterion] = normalizedScore * weight;
                    }
                    else
                    {
                        // Handle cases where a criterion might not have an assigned weight
                        weightedScores[criterion] = 0;
                    }
                }

                weightedPlayerScores[playerScore.Key] = weightedScores;
            }

            return weightedPlayerScores;
        }
    }
}
