namespace CoachAssistant.Client.Entities
{
    public class MatchLineupPositionPlayerViewEntity
    {
        public Guid Id { get; set; }

        public Guid MatchLineupPositionId { get; set; }

        public Guid PlayerId { get; set; }

        public double Score { get; set; }
    }
}
