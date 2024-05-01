using Domain.Interfaces;

namespace Domain.Entities
{
    public class Training : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public float Duration { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }

        public IReadOnlyCollection<Player> Players { get; set; }

        public IReadOnlyCollection<TrainingRecord> TrainingRecords { get; set; }
    }
}
