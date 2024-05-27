using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Entities
{
    public class MatchLineupPositionViewEntity
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public Guid MatchTeamId { get; set; }

        public IReadOnlyCollection<MatchLineupPositionPlayerViewEntity> MatchLineupPositionPlayers { get; set; }
    }
}
