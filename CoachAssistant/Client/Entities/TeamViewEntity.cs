using CoachAssistant.Shared;

namespace CoachAssistant.Client.Entities
{
    public class TeamViewEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public VerificationState VerificationState { get; set; }

        public List<TrainingViewEntity> Trainings { get; set; }

        public List<PlayerViewEntity> Players { get; set; }
    }
}
