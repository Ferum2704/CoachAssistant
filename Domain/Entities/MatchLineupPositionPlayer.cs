using Domain.Interfaces;

namespace Domain.Entities
{
    public class MatchLineupPositionPlayer : IEntity
    {
        public Guid Id { get; set; }

        public Guid MatchLineupPositionId { get; set; }

        public MatchLineupPosition MatchLineupPosition { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }
    }
}
