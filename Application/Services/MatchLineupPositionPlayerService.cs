using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class MatchLineupPositionPlayerService : IMatchLineupPositionPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchLineupPositionPlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<MatchLineupPositionPlayerViewModel> Add(MatchLineupPositionPlayerModel model)
        {
            var matchLineupPositionPlayer = mapper.Map<MatchLineupPositionPlayer>(model);

            unitOfWork.MatchLineupPositionPlayerRepository.Add(matchLineupPositionPlayer);
            await unitOfWork.SaveAsync();

            return mapper.Map<MatchLineupPositionPlayerViewModel>(matchLineupPositionPlayer);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public Task<MatchLineupPositionPlayerViewModel> Edit(Guid id, MatchLineupPositionPlayerModel model)
        {
            throw new NotImplementedException();
        }

        public Task<MatchLineupPositionPlayerViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<MatchLineupPositionPlayerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveByPositionId(Guid positionId)
        {
            var positionPlayers = await unitOfWork.MatchLineupPositionPlayerRepository.GetAsync(x => x.MatchLineupPositionId == positionId);

            unitOfWork.MatchLineupPositionPlayerRepository.RemoveRange(positionPlayers);
            await unitOfWork.SaveAsync();
        }
    }
}
