using CoachAssistant.Client.Network;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class TeamService
    {
        public List<ClubViewModel> Teams { get; private set; } = new();
        public Dictionary<Guid, List<ClubViewModel>> TournamentsTeams { get; private set; } = new();

        private readonly IHttpClientService httpClientService;

        public TeamService(IHttpClientService httpClientService)
        {
            this.httpClientService = httpClientService;
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
