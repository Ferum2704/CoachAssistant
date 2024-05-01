using Domain.Interfaces;

namespace Domain.Entities
{
    public class Criterion : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<TrainingMark> TrainingMarks { get; set; }

        public IReadOnlyCollection<Position> Positions { get; set; }

        public IReadOnlyCollection<PositionCriteria> PositionCriteria { get; set; }
    }
}
