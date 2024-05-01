using Domain.Interfaces;

namespace Domain.Entities
{
    public class MatchLineupPosition : IEntity
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }

        public Guid MatchTeamId { get; set; }

        public MatchTeam Match { get; set; }

        public IReadOnlyCollection<Player> Players { get; set; }

        public IReadOnlyCollection<MatchLineupPositionPlayer> MatchLineupPositionPlayers { get; set; }
    }
}
