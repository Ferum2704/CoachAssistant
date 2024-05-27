using Application.Abstractions;
using Application.Abstractions.Lineup;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

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

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public async Task<MatchTeamViewModel> Edit(Guid id, MatchTeamModel model)
        {     
            var matchTeam = await unitOfWork.MatchTeamRepository.GetByIdAsync(id);

            if (matchTeam.NumberOfDefenders != model.NumberOfDefenders)
            {
                matchTeam.NumberOfDefenders = model.NumberOfDefenders;
            }
            else if (matchTeam.NumberOfMidfielders != model.NumberOfMidfielders)
            {
                matchTeam.NumberOfMidfielders = model.NumberOfMidfielders;
            }
            else if (matchTeam.NumberOfForwards != model.NumberOfForwards)
            {
                matchTeam.NumberOfForwards = model.NumberOfForwards;
            }

            unitOfWork.MatchTeamRepository.Update(matchTeam);
            await unitOfWork.SaveAsync();

            var matchLineupPositions = await unitOfWork.MatchLineupPositionRepository.GetAsync(x => x.MatchTeamId == id);
            var positions = await GetPositionsForTactic(model.NumberOfDefenders, model.NumberOfMidfielders, model.NumberOfForwards);

            foreach (var position in positions.Where(p => matchLineupPositions.Any(x => x.PositionId == p.Key.Id)))
            {
                for (int i = 0; i < position.Value; i++)
                {
                    var matchLineupPosition = new MatchLineupPosition()
                    {
                        Id = Guid.NewGuid(),
                        MatchTeamId = id,
                        PositionId = position.Key.Id
                    };

                    unitOfWork.MatchLineupPositionRepository.Add(matchLineupPosition);
                }
            }

            await unitOfWork.SaveAsync();

            return mapper.Map<MatchTeamViewModel>(matchTeam);
        }

        public async Task<MatchTeamViewModel> Get(Guid id)
        {
            var matchTeam = await unitOfWork.MatchTeamRepository.GetByIdAsync(id);

            return mapper.Map<MatchTeamViewModel>(matchTeam);
        }

        public Task<IReadOnlyCollection<MatchTeamViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        private async Task<Dictionary<Position, int>> GetPositionsForTactic(int numberOfDefenders, int numberOfMidfielders, int numberOfForwards)
        {
            string[] positionNames;
            Dictionary<Position, int> formationPositions = new Dictionary<Position, int>();

            if (numberOfDefenders == 4 && numberOfMidfielders == 3 && numberOfForwards == 3)
            {
                positionNames = new string[] { "Goalkeeper", "Center-back", "Center-back", "Right back", "Left back", 
                    "Defensive midfielder", "Center midfielder", "Center midfielder", "Right Winger", "Left Winger", "Center Forward" };

                var positions = await unitOfWork.PositionRepository.GetAsync(x => positionNames.Contains(x.Name));

                foreach (var position in positions)
                {
                    formationPositions[position] = positionNames.Where(x => x == position.Name).Count();
                }
            }

            return formationPositions;
        }
    }
}
