namespace CoachAssistant.Shared.ViewModels
{
    public class TournamentViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public TournamentType TournamentType { get; set; }

        public IReadOnlyCollection<MatchViewModel> Matches { get; set; }
    }
}
