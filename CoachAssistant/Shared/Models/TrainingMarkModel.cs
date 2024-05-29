using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Shared.Models
{
    public class TrainingMarkModel
    {
        public Guid? TrainingRecordId { get; set; }

        public Guid? CriterionId { get; set; }

        public float Mark { get; set; }
    }
}
