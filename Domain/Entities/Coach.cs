namespace Domain.Entities
{
    public class Coach : DomainUser
    {
        public Guid TeamId { get; set; }

        public Team Team { get; set; }
    }
}
