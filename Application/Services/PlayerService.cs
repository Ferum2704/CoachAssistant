using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITrainingRecordService trainingRecordService;
        private readonly IMapper mapper;

        public PlayerService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ITrainingRecordService trainingRecordService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.trainingRecordService = trainingRecordService;
        }

        public async Task<PlayerViewModel> Add(PlayerModel model)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Surname = model.Surname,
                Weight = model.Weight,
                Height = model.Height,
                Email = model.Email,
                TeamId = model.TeamId.Value,
                PhotoPath = model.PhotoPath
            };

            unitOfWork.PlayerRepository.Add(player);
            await unitOfWork.SaveAsync();

            return mapper.Map<PlayerViewModel>(player);
        }

        public async Task Delete(Guid id)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(id);

            if (player is not null)
            {
                var trainingRecords = await unitOfWork.TrainingRecordRepository.GetAsync(x => x.PlayerId == player.Id);
                var matchActions = await unitOfWork.MatchPlayerActionRepository.GetAsync(x => x.PlayerId == player.Id);
                var positions = await unitOfWork.MatchLineupPositionPlayerRepository.GetAsync(x => x.PlayerId == id);

                await trainingRecordService.DeleteBulk(trainingRecords.Select(x => x.Id).ToList());
                unitOfWork.MatchPlayerActionRepository.RemoveRange(matchActions);
                unitOfWork.MatchLineupPositionPlayerRepository.RemoveRange(positions);

                unitOfWork.PlayerRepository.Remove(player);
                await unitOfWork.SaveAsync();
            }
        }

        public Task DeleteBulk<TEntity>(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBulk(IReadOnlyCollection<Guid> IDs)
        {
            throw new NotImplementedException();
        }

        public async Task<PlayerViewModel> Edit(Guid id, PlayerModel model)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(id);

            if (player.Name != model.Name)
            {
                player.Name = model.Name;
            }
            else if(player.Surname != model.Surname)
            {
                player.Surname = model.Surname;
            }
            else if (player.Weight != model.Weight)
            {
                player.Weight = model.Weight;
            }
            else if (player.Height != model.Height)
            {
                player.Height = model.Height;
            }
            else if (player.Email != model.Email)
            {
                player.Email = model.Email;
            }
            else if (player.PhotoPath != model.PhotoPath)
            {
                player.Email = model.Email;
            }

            unitOfWork.PlayerRepository.Update(player);
            await unitOfWork.SaveAsync();

            return mapper.Map<PlayerViewModel>(player);
        }

        public async Task<PlayerViewModel> Get(Guid id)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(id);

            return mapper.Map<PlayerViewModel>(player);
        }

        public async Task<IReadOnlyCollection<PlayerViewModel>> GetAll()
        {
            var players = await unitOfWork.PlayerRepository.GetAsync();

            return mapper.Map<IReadOnlyCollection<PlayerViewModel>>(players);
        }

        public async Task<IReadOnlyCollection<PlayerViewModel>> GetPlayersByTeamIdAsync(Guid teamId)
        {
            var players = await unitOfWork.PlayerRepository.GetAsync(x => x.TeamId == teamId);

            return mapper.Map<IReadOnlyCollection<PlayerViewModel>>(players);
        }
    }
}
