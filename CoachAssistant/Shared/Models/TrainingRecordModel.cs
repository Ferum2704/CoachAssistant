namespace CoachAssistant.Shared.Models
{
    public class TrainingRecordModel
    {
        public Guid? TrainingId { get; set; }

        public Guid? PlayerId { get; set; }

        public bool? IsPresent { get; set; }

        public string? Note { get; set; }
    }
}
