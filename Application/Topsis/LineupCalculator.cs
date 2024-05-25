using Application.Abstractions;
using Application.Abstractions.IRepository;
using Application.Abstractions.Lineup;
using Domain.Entities;

namespace Application.Topsis
{
    public class LineupCalculator : ILineupCalculator
    {
        private readonly ITopsisCalculator topsisCalculator;
        private readonly IUnitOfWork unitOfWork;

        public LineupCalculator(ITopsisCalculator topsisCalculator, IUnitOfWork unitOfWork)
        {
            this.topsisCalculator = topsisCalculator;
            this.unitOfWork = unitOfWork;
        }

        public async Task CalculateBestLineup(MatchTeam matchTeam)
        {
            var teamTrainings = await unitOfWork.TrainingRepository.GetAsync(x => x.TeamId == matchTeam.TeamId);
            var lastThreeTrainings = teamTrainings.OrderByDescending(x => x.StartDate).Take(3).ToList();

            var bestPlayers = new List<Player>();
            foreach (var lineupPosition in matchTeam.LineupPositions)
            {
                lineupPosition.Position = await unitOfWork.PositionRepository.GetByIdAsync(lineupPosition.PositionId);

                var teamPlayers = await unitOfWork.PlayerRepository.GetAsync(x => x.TeamId == matchTeam.TeamId && !bestPlayers.Contains(x));

                var rankedPlayers = await topsisCalculator.CalculateBestPlayers(teamPlayers, lineupPosition.Position, lastThreeTrainings);

                if (rankedPlayers != null)
                {
                    bestPlayers.Add(rankedPlayers.First().Key);

                    foreach (var player in rankedPlayers.Take(5))
                    {
                        var positionPlayer = new MatchLineupPositionPlayer()
                        {
                            Id = Guid.NewGuid(),
                            MatchLineupPositionId = lineupPosition.Id,
                            PlayerId = player.Key.Id,
                            Score = player.Value
                        };

                        unitOfWork.MatchLineupPositionPlayerRepository.Add(positionPlayer);
                        await unitOfWork.SaveAsync();
                    }
                }
            }
        }
    }
}
