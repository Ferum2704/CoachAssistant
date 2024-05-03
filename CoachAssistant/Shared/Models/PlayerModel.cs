namespace CoachAssistant.Shared.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public float Height { get; set; }

        public float Weight { get; set; }

        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public Guid TeamId { get; set; }
    }
}
