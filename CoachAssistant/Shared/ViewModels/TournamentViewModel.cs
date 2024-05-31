namespace CoachAssistant.Shared.ViewModels
{
    public class TournamentViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TournamentType { get; set; }

        public IReadOnlyCollection<MatchViewModel> Matches { get; set; }

        public IReadOnlyCollection<TournamentTeamViewModel> TournamentTeams { get; set; }
    }
}
