using Application.Abstractions;
using Application.Services.IService;
using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Services
{
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;

        public ClubService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.currentUserService = currentUserService;
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
                CoachId = currentUserService.CurrentUserId
            };

            unitOfWork.TeamRepository.Add(team);
            await unitOfWork.SaveAsync();

            var clubViewModel = mapper.Map<ClubViewModel>(club);
            clubViewModel.Team = mapper.Map<TeamViewModel>(team);

            return clubViewModel;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Guid id, TeamClubModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ClubViewModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
