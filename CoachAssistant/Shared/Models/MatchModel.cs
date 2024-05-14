namespace CoachAssistant.Shared.Models
{
    public class MatchModel
    {
        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public MatchType MatchType { get; set; }

        public Guid TournamentId { get; set; }
    }
}
