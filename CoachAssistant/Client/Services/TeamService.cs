using CoachAssistant.Client.Network;
using CoachAssistant.Client.Services.Abstractions;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TeamService
    {
        public List<ClubViewModel> Teams { get; private set; } = new();
        public Dictionary<Guid, List<ClubViewModel>> TournamentsTeams { get; private set; } = new();

        private readonly IHttpClientService httpClientService;
        private readonly ICurrentTeamProvider currentTeamProvider;

        public TeamService(IHttpClientService httpClientService, ICurrentTeamProvider currentTeamProvider)
        {
            this.httpClientService = httpClientService;
            this.currentTeamProvider = currentTeamProvider;
        }

        public async Task LoadTeams() =>
            Teams = await httpClientService.GetAsync<List<ClubViewModel>>(ApiUrls.TeamsUrl);

        public async Task<List<ClubViewModel>> GetTournamentTeams(Guid tournamentId)
        {
            if (!TournamentsTeams.ContainsKey(tournamentId))
            {
                var teams = await httpClientService.GetAsync<List<ClubViewModel>>(ApiUrls.GetTournamentTeamsUrl(tournamentId));
                TournamentsTeams[tournamentId] = teams;
            }

            return TournamentsTeams[tournamentId];
        }

        public async Task GetCoachTeam()
        {
            var clubViewModel = await httpClientService.GetAsync<ClubViewModel>(ApiUrls.CoachTeamUrl);

            if (clubViewModel is not null)
            {
                currentTeamProvider.CurrentClub = clubViewModel;
            }
        }

        public async Task<ClubViewModel> Add(TeamClubModel model) =>
            await httpClientService.PostAsync<TeamClubModel, ClubViewModel>(ApiUrls.TeamsUrl, model);

        public async Task<ClubViewModel> Edit(Guid teamId, TeamClubModel model) =>
            await httpClientService.PutAsync<TeamClubModel, ClubViewModel>(ApiUrls.GetTeamByIdUrl(teamId), model);

        public async Task Delete(Guid clubdId) =>
            await httpClientService.DeleteAsync(ApiUrls.GetTeamByIdUrl(clubdId));

        public async Task SendTeamForVerification(Guid clubId) =>
            await httpClientService.PutAsync(ApiUrls.GetSendTeamForVerificationUrl(clubId));

        public async Task AcceptVerification(Guid clubId) =>
            await httpClientService.PutAsync(ApiUrls.GetAcceptTeamVerificationUrl(clubId));

        public async Task RejectVerification(Guid clubId) =>
            await httpClientService.PutAsync(ApiUrls.GetRejectTeamVerificationUrl(clubId));
    }
}
