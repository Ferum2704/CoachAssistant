using Domain.Interfaces;

namespace Domain.Entities
{
    public class PositionCriteria : IEntity
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }

        public Guid CriterionId { get; set; }

        public Criterion Criterion { get; set; }

        public float Weight { get; set; }
    }
}
