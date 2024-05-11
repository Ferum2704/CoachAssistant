using Domain.Entities;

namespace Application.Abstractions.Lineup
{
    public interface ILineupCalculator
    {
        Task CalculateBestLineup(MatchTeam matchTeam);
    }
}
