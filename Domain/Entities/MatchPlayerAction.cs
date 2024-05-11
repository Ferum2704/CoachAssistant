using Domain.Interfaces;

namespace Domain.Entities
{
    public class MatchPlayerAction : IEntity
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid MatchId { get; set; }

        public Match Match { get; set; }

        public Guid ActionTypeId { get; set; }

        public ActionType ActionType { get; set; }

        public int ActionNumber { get; set; }
    }
}
