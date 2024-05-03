namespace CoachAssistant.Client.Entities
{
    public class ClubViewEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Stadium { get; set; }

        public TeamViewEntity Team { get; set; }
    }
}
