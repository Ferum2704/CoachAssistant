namespace CoachAssistant.Shared.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public VerificationState VerificationState { get; set; }

        public IReadOnlyCollection<TrainingViewModel> Trainings { get; set; }

        public IReadOnlyCollection<PlayerViewModel> Players { get; set; }
    }
}
