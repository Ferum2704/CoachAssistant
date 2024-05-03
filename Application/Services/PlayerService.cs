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
        private readonly IMapper mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
                TeamId = model.TeamId,
                PhotoPath = model.PhotoPath
            };

            unitOfWork.PlayerRepository.Add(player);
            await unitOfWork.SaveAsync();

            return mapper.Map<PlayerViewModel>(model);
        }

        public async Task Delete(Guid id)
        {
            var player = await unitOfWork.PlayerRepository.GetByIdAsync(id);

            if (player is not null)
            {
                unitOfWork.PlayerRepository.Remove(player);
                await unitOfWork.SaveAsync();
            }
        }

        public async Task Edit(Guid id, PlayerModel model)
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
        }

        public Task<PlayerViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
