using Domain.Interfaces;

namespace Domain.Entities
{
    public class Position : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<PositionCriteria> PositionCriteria { get; set; }

        public IReadOnlyCollection<Criterion> Criteria { get; set; }
    }
}
