using System.ComponentModel.DataAnnotations;

namespace CoachAssistant.Shared.ViewModels
{
    public class TrainingViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введіть назву тренування")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Виберіть дату початку")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Виберіть час початку")]
        public TimeSpan? StartTime { get; set; }

        [Required(ErrorMessage = "Вкажіть тривалість тренування")]
        [Range(0.5, 24, ErrorMessage = "Тривалість повинна бути між 0.5 та 24 годинами")]
        public float Duration { get; set; }

        public Guid TeamId { get; set; }

        public IReadOnlyCollection<TrainingRecordViewModel> TrainingRecords { get; set;}
    }
}
