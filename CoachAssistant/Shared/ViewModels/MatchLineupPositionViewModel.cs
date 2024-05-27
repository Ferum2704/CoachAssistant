namespace CoachAssistant.Shared.ViewModels
{
    public class MatchLineupPositionViewModel
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public PositionViewModel Position { get; set; }

        public Guid MatchTeamId { get; set; }

        public IReadOnlyCollection<MatchLineupPositionPlayerViewModel> MatchLineupPositionPlayers { get; set; }
    }
}
