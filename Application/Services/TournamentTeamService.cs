using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class TournamentTeamService : ITournamentTeamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TournamentTeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TournamentTeamViewModel> Add(TournamentTeamModel model)
        {
            var tournamentTeam = mapper.Map<TournamentTeam>(model);

            unitOfWork.TournamentTeamRepository.Add(tournamentTeam);
            await unitOfWork.SaveAsync();

            return mapper.Map<TournamentTeamViewModel>(tournamentTeam);
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

        public Task Edit(Guid id, TournamentTeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<TournamentTeamViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<TournamentTeamViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
