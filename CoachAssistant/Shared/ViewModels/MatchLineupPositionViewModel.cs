namespace CoachAssistant.Shared.ViewModels
{
    public class MatchLineupPositionViewModel
    {
        public Guid Id { get; set; }

        public Guid PositionId { get; set; }

        public PositionViewModel Position { get; set; }

        public Guid MatchTeamId { get; set; }

        public List<MatchLineupPositionPlayerViewModel> MatchLineupPositionPlayers { get; set; }
    }
}
