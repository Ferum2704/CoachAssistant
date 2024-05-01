using Domain.Interfaces;

namespace Domain.Entities
{
    public class Club : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Stadium { get; set; }

        public Guid TeamId { get; set; }

        public Team Team { get; set; }
    }
}
