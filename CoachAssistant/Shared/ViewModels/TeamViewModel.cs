namespace CoachAssistant.Shared.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CoachId { get; set; }

        public VerificationState VerificationState { get; set; }

        public List<TrainingViewModel> Trainings { get; set; }

        public List<PlayerViewModel> Players { get; set; }
    }
}
