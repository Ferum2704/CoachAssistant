namespace CoachAssistant.Shared.ViewModels
{
    public class TrainingRecordViewModel
    {
        public Guid Id { get; set; }

        public Guid TrainingId { get; set; }

        public Guid PlayerId { get; set; }

        public bool IsPresent { get; set; }

        public string? Note { get; set; }

        public IReadOnlyCollection<TrainingMarkViewModel> TrainingMarks { get; set; }
    }
}
