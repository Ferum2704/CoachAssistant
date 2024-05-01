using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class MatchTeam : IEntity
    {
        public Guid Id { get; set; }

        public Guid MatchId { get; set; }

        public Match Match { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public IReadOnlyCollection<MatchLineupPosition> LineupPositions { get; set; }

        public MatchTeamType TeamType { get; set; }

        public int NumberOfDefenders { get; set; }

        public int NumberOfMidfielders { get; set; }

        public int NumberOfForwards { get; set; }
    }
}
