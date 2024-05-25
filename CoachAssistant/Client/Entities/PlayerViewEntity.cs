namespace CoachAssistant.Client.Entities
{
    public class PlayerViewEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string Email { get; set; }
    }
}
