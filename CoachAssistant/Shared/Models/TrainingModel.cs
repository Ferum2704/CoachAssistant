namespace CoachAssistant.Shared.Models
{
    public class TrainingModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public float Duration { get; set; }

        public Guid? TeamId { get; set; }
    }
}
