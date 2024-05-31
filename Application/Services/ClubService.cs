using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services
{
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;
        private readonly IPlayerService playerService;
        private readonly ITrainingService trainingService;

        public ClubService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService, IPlayerService playerService, ITrainingService trainingService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
            this.playerService = playerService;
            this.trainingService = trainingService;
        }

        public async Task<ClubViewModel> Add(TeamClubModel model)
        {
            var club = mapper.Map<Club>(model);

            unitOfWork.ClubRepository.Add(club);

            var team = new Team()
            {
                Id = Guid.NewGuid(),
                Name = club.Name,
                ClubId = club.Id,
                VerificationState = VerificationState.NotVerified,
                CoachId = currentUserService.CurrentUserId
            };

            unitOfWork.TeamRepository.Add(team);
            await unitOfWork.SaveAsync();

            var clubViewModel = mapper.Map<ClubViewModel>(club);
            clubViewModel.Team = mapper.Map<TeamViewModel>(team);

            return clubViewModel;
        }

        public async Task Delete(Guid id)
        {
            var team = await unitOfWork.TeamRepository.GetSingleAsync(x => x.ClubId == id);
            var club = await unitOfWork.ClubRepository.GetSingleAsync(x => x.Id == id);

            var players = await unitOfWork.PlayerRepository.GetAsync(x => x.TeamId == team.Id);
            foreach (var player in players)
            {
                await playerService.Delete(player.Id);
            }

            var trainings = await unitOfWork.TrainingRepository.GetAsync(x => x.TeamId == team.Id);
            foreach (var training in trainings)
            {
                await trainingService.Delete(training.Id);
            }

            unitOfWork.TeamRepository.Remove(team);

            unitOfWork.ClubRepository.Remove(club);
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

        public async Task<ClubViewModel> Edit(Guid id, TeamClubModel model)
        {
            var club = await unitOfWork.ClubRepository.GetByIdAsync(id);

            if (club is not null)
            {
                if (club.Name != model.Name && model.Name is not null)
                {
                    club.Team.Name = model.Name;
                    club.Name = model.Name;
                }
                if (club.City != model.City && model.City is not null)
                {
                    club.City = model.City;
                }
                if (club.Stadium != model.Stadium && model.Stadium is not null)
                {
                    club.Stadium = model.Stadium;
                }
                if (club.Region != model.Region && model.Region is not null)
                {
                    club.Region = model.Region;
                }

                unitOfWork.ClubRepository.Update(club);
                unitOfWork.TeamRepository.Update(club.Team);

                await unitOfWork.SaveAsync();
            }

            return mapper.Map<ClubViewModel>(club);
        }

        public async Task<ClubViewModel> Get(Guid id)
        {
            var club = await unitOfWork.ClubRepository.GetByIdAsync(id);
            var team = await unitOfWork.TeamRepository.GetByIdAsync(club.Team.Id);

            var clubViewModel = mapper.Map<ClubViewModel>(club);
            clubViewModel.Team = mapper.Map<TeamViewModel>(team);

            return clubViewModel;
        }

        public async Task<IReadOnlyCollection<ClubViewModel>> GetAll()
        {
            var clubs = await unitOfWork.ClubRepository.GetAsync();

            return mapper.Map<IReadOnlyCollection<ClubViewModel>>(clubs);
        }

        public async Task<ClubViewModel> GetByCoachId(Guid coachId)
        {
            var team = await unitOfWork.TeamRepository.GetSingleAsync(x => x.CoachId == coachId);

            if (team is null)
            {
                return null;   
            }

            var club = await unitOfWork.ClubRepository.GetByIdAsync(team.ClubId);

            var clubViewModel = mapper.Map<ClubViewModel>(club);
            clubViewModel.Team = mapper.Map<TeamViewModel>(team);

            return clubViewModel;
        }

        public async Task<List<ClubViewModel>> GetByTournamentId(Guid tournamentId)
        {
            var teams = await unitOfWork.TeamRepository.GetAsync(x => x.Tournaments.Select(t => t.Id).Contains(tournamentId));

            var clubs = await unitOfWork.ClubRepository.GetAsync(x => teams.Select(t => t.ClubId).Contains(x.Id));

            return mapper.Map<List<ClubViewModel>>(clubs);
        }

        public async Task AcceptVerification(Guid clubId)
        {
            var club = await unitOfWork.ClubRepository.GetByIdAsync(clubId);

            club.Team.VerificationState = VerificationState.Verified;

            unitOfWork.TeamRepository.Update(club.Team);
            await unitOfWork.SaveAsync();
        }

        public async Task RejectVerification(Guid clubId)
        {
            var club = await unitOfWork.ClubRepository.GetByIdAsync(clubId);

            club.Team.VerificationState = VerificationState.NotVerified;

            unitOfWork.TeamRepository.Update(club.Team);
            await unitOfWork.SaveAsync();
        }

        public async Task SendForVerification(Guid clubId)
        {
            var club = await unitOfWork.ClubRepository.GetByIdAsync(clubId);

            club.Team.VerificationState = VerificationState.InProgress;

            unitOfWork.TeamRepository.Update(club.Team);
            await unitOfWork.SaveAsync();
        }
    }
}
