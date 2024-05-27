using CoachAssistant.Shared;

namespace CoachAssistant.Client.Entities
{
    public class MatchTeamViewEntity
    {
        public Guid Id { get; set; }

        public Guid MatchId { get; set; }

        public Guid TeamId { get; set; }

        public MatchTeamType TeamType { get; set; }

        public int NumberOfDefenders { get; set; }

        public int NumberOfMidfielders { get; set; }

        public int NumberOfForwards { get; set; }

        public IReadOnlyCollection<MatchLineupPositionViewEntity> LineupPositions { get; set; }
    }
}
