namespace CoachAssistant.Shared.Models
{
    public class TeamClubModel
    {
        public string? Name { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Stadium { get; set; }

        public VerificationState? VerificationState { get; set; }
    }
}
