namespace CoachAssistant.Shared.ViewModels
{
    public class MatchPlayerActionViewModel
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public Guid MatchId { get; set; }

        public Guid ActionTypeId { get; set; }

        public ActionTypeViewModel ActionType { get; set; }

        public int ActionNumber { get; set; }
    }
}
