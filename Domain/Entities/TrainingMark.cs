using Domain.Interfaces;

namespace Domain.Entities
{
    public class TrainingMark : IEntity
    {
        public Guid Id { get; set; }

        public Guid TrainingRecordId { get; set; }

        public TrainingRecord TrainingRecord { get; set; }

        public Guid CriterionId { get; set; }

        public Criterion Criterion { get; set; }

        public float Mark { get; set; }
    }
}
