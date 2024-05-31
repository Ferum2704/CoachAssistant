using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services.IService
{
    public interface IClubService : IService<TeamClubModel, ClubViewModel>
    {
        Task<ClubViewModel> GetByCoachId(Guid coachId);

        Task<List<ClubViewModel>> GetByTournamentId(Guid tournamentId);

        Task SendForVerification(Guid clubId);

        Task AcceptVerification(Guid clubId);

        Task RejectVerification(Guid clubId);
    }
}
