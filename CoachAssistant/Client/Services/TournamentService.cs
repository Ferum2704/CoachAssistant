using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
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

        public void RemoveTournament(TournamentViewModel tournament)
        {
            Tournaments.Remove(tournament);
            NotifyStateChanged();
        }

        public async Task<TournamentViewModel> Add(TournamentModel model) =>
            await httpClientService.PostAsync<TournamentModel, TournamentViewModel>(ApiUrls.TournamentsUrl, model);

        public async Task<TournamentViewModel> GetTournamentById(string id) =>
            await httpClientService.GetAsync<TournamentViewModel>(ApiUrls.GetTournamentByIdUrl(id));

        public async Task<TournamentViewModel> GenerateSchedule(string tournamentId) =>
            await httpClientService.PostAsync<TournamentViewModel>(ApiUrls.GetMatchesByTournamentIdUrl(tournamentId));

        public async Task<TournamentViewModel> Edit(string tournamentId, TournamentModel model) =>
            await httpClientService.PutAsync<TournamentModel, TournamentViewModel>(ApiUrls.GetTournamentByIdUrl(tournamentId), model);

        public async Task Delete(string tournamentId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetTournamentByIdUrl(tournamentId));

        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
