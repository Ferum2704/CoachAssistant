namespace Domain.Entities
{
    public class Coach : DomainUser
    {
        public Team? Team { get; set; }
    }
}
