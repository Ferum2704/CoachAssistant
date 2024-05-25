namespace CoachAssistant.Shared.ViewModels
{
    public class MatchLineupPositionPlayerViewModel
    {
        public Guid Id { get; set; }

        public Guid MatchLineupPositionId { get; set; }

        public Guid PlayerId { get; set; }

        public double Score { get; set; }
    }
}
