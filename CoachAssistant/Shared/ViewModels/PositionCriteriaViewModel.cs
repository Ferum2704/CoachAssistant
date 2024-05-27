namespace CoachAssistant.Shared.ViewModels
{
    public class PositionCriteriaViewModel
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Guid CriterionId { get; set; }

        public CriterionViewModel Criterion { get; set; }

        public float Weight { get; set; }
    }
}
