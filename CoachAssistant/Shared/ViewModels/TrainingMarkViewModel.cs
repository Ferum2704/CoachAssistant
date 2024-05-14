namespace CoachAssistant.Shared.ViewModels
{
    public class TrainingMarkViewModel
    {
        public Guid Id { get; set; }

        public Guid TrainingRecordId { get; set; }

        public Guid CriterionId { get; set; }

        public float Mark { get; set; }
    }
}
