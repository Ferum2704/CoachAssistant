using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services.IService
{
    public interface IMatchTeamService : IService<MatchTeamModel, MatchTeamViewModel>
    {
        Task<MatchTeamViewModel> CalculateLineUp(Guid matchTeamId);
    }
}
