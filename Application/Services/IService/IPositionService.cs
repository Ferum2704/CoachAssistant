using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services.IService
{
    public interface IPositionService : IService<PositionModel, PositionViewModel>
    {
    }
}
