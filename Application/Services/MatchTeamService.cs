using Application.Abstractions;
using Application.Abstractions.Lineup;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace Application.Services
{
    public class MatchTeamService : IMatchTeamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILineupCalculator lineupCalculator;
        private readonly IMapper mapper;

        public MatchTeamService(IUnitOfWork unitOfWork, IMapper mapper, ILineupCalculator lineupCalculator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.lineupCalculator = lineupCalculator;
        }

        public Task<MatchTeamViewModel> Add(MatchTeamModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchTeamViewModel> CalculateLineUp(Guid matchTeamId)
        {
            var matchTeam = await unitOfWork.MatchTeamRepository.GetByIdAsync(matchTeamId);

            await lineupCalculator.CalculateBestLineup(matchTeam);

            matchTeam = await unitOfWork.MatchTeamRepository.GetByIdAsync(matchTeamId);

            return mapper.Map<MatchTeamViewModel>(matchTeam);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, MatchTeamModel model)
        {
            throw new NotImplementedException();
        }

        public Task<MatchTeamViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
