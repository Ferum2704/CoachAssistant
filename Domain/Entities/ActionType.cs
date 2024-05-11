using Domain.Interfaces;

namespace Domain.Entities
{
    public class ActionType : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double BenchmarkValue { get; set; }
    }
}
