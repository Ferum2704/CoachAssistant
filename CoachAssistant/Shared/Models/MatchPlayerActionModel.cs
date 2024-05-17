namespace CoachAssistant.Shared.Models
{
    public class MatchPlayerActionModel
    {
        public Guid PlayerId { get; set; }

        public Guid MatchId { get; set; }

        public Guid ActionTypeId { get; set; }

        public int ActionNumber { get; set; }
    }
}
