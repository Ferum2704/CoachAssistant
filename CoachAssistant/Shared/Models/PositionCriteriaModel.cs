namespace CoachAssistant.Shared.Models
{
    public class PositionCriteriaModel
    {
        public Guid? PositionId { get; set; }

        public Guid? CriterionId { get; set; }

        public float Weight { get; set; }
    }
}
