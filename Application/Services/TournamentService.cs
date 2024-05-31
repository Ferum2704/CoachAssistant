using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITournamentMatchesGenerator tournamentMatchesGenerator;
        private readonly IMapper mapper;

        public TournamentService(IUnitOfWork unitOfWork, IMapper mapper, ITournamentMatchesGenerator tournamentMatchesGenerator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.tournamentMatchesGenerator = tournamentMatchesGenerator;
        }

        public async Task<TournamentViewModel> Add(TournamentModel model)
        {
            var tournament = mapper.Map<Tournament>(model);

            unitOfWork.TournamentRepository.Add(tournament);
            await unitOfWork.SaveAsync();

            return mapper.Map<TournamentViewModel>(tournament);
        }

        public async Task Delete(Guid id)
        {
            var tournament = await unitOfWork.TournamentRepository.GetByIdAsync(id);

            unitOfWork.TournamentRepository.Remove(tournament);
            await unitOfWork.SaveAsync();
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public async Task<TournamentViewModel> Edit(Guid id, TournamentModel model)
        {
            var tournament = await unitOfWork.TournamentRepository.GetByIdAsync(id);

            if (tournament is not null)
            {
                if (tournament.Name != model.Name)
                {
                    tournament.Name = model.Name;
                }

                Enum.TryParse(model.Name, out TournamentType newType);
                if (tournament.TournamentType.ToString() != newType.ToString())
                {
                    tournament.TournamentType = newType;
                }
                unitOfWork.TournamentRepository.Update(tournament);
                await unitOfWork.SaveAsync();
            }

            return mapper.Map<TournamentViewModel>(tournament);
        }

        public async Task<TournamentViewModel> GenerateTournamentMatches(Guid tournamentId)
        {
            await tournamentMatchesGenerator.Generate(tournamentId);

            var tournament = await unitOfWork.TournamentRepository.GetByIdAsync(tournamentId);

            return mapper.Map<TournamentViewModel>(tournament);
        }

        public async Task<TournamentViewModel> Get(Guid id)
        {
            var tournament = await unitOfWork.TournamentRepository.GetByIdAsync(id);

            return mapper.Map<TournamentViewModel>(tournament);
        }

        public async Task<IReadOnlyCollection<TournamentViewModel>> GetAll()
        {
            var tournaments = await unitOfWork.TournamentRepository.GetAsync();

            return mapper.Map<IReadOnlyCollection<TournamentViewModel>>(tournaments);
        }

        public async Task<IReadOnlyCollection<TournamentViewModel>> GetByTeamId(Guid teamId)
        {
            var tournaments = await unitOfWork.TournamentRepository.GetAsync(x => x.TournamentTeams.Select(x => x.TeamId).Contains(teamId));

            return mapper.Map<IReadOnlyCollection<TournamentViewModel>>(tournaments);
        }
    }
}
