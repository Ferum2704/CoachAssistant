using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MatchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<MatchViewModel> Add(MatchModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, MatchModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchViewModel> Get(Guid id)
        {
            var match = await unitOfWork.MatchRepository.GetByIdAsync(id);

            return mapper.Map<MatchViewModel>(match);
        }

        public Task<IReadOnlyCollection<MatchViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
