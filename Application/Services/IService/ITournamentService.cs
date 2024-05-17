using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services.IService
{
    public interface ITournamentService : IService<TournamentModel, TournamentViewModel>
    {
        Task<TournamentViewModel> GenerateTournamentMatches(Guid tournamentId);
    }
}
