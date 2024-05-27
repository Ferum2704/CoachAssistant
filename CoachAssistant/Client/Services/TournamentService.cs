using CoachAssistant.Client.Network;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TournamentService
    {
        public List<TournamentViewModel> Tournaments { get; private set; } = new();
        public event Action OnChange;

        private readonly IHttpClientService httpClientService;

        public TournamentService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
        }

        public async Task LoadTournaments()
        {
            Tournaments = await httpClientService.GetAsync<List<TournamentViewModel>>(ApiUrls.TournamentsUrl);
            NotifyStateChanged();
        }

        public async Task LoadTeamTournaments(Guid teamId)
        {
            Tournaments = await httpClientService.GetAsync<List<TournamentViewModel>>(ApiUrls.GetTeamTournamentsUrl(teamId));
            NotifyStateChanged();
        }

        public void AddTournament(TournamentViewModel tournament)
        {
            Tournaments.Add(tournament);
            NotifyStateChanged();
        }

        public async Task<TournamentViewModel> GetTournamentById(string id) =>
            await httpClientService.GetAsync<TournamentViewModel>(ApiUrls.GetTournamentByIdUrl(id));

        public async Task<TournamentViewModel> GenerateSchedule(string tournamentId) =>
            await httpClientService.PostAsync<TournamentViewModel>(ApiUrls.GetMatchesByTournamentIdUrl(tournamentId));

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
