using Domain.Interfaces;

namespace Domain.Entities
{
    public class TrainingRecord : IEntity
    {
        public Guid Id { get; set; }

        public Guid TrainingId { get; set; }

        public Training Training { get; set; }

        public Guid PlayerId { get; set; }

        public Player Player { get; set; }

        public bool IsPresent { get; set; }

        public string Note { get; set; }

        public IReadOnlyCollection<TrainingMark> TrainingMarks { get; set; }
    }
}
