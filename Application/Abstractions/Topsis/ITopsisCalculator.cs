using Domain.Entities;

namespace Application.Abstractions.Lineup
{
    public interface ITopsisCalculator
    {
        Task<Dictionary<Player, double>> CalculateBestPlayers(IReadOnlyCollection<Player> players, Position position, IReadOnlyCollection<Training> trainings);
    }
}
