using Application.Abstractions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clubs
{
    public class AddTeamClubCommandHandler : IRequestHandler<AddTeamClubCommand>
    {
        private readonly IMediator mediator;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddTeamClubCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task Handle(AddTeamClubCommand request, CancellationToken cancellationToken)
        {
            var club = mapper.Map<Club>(request);

            unitOfWork.ClubRepository.Add(club);

            var team = new Team()
            {
                Id = Guid.NewGuid(),
                Name = club.Name,
                ClubId = club.Id,
                CoachId = request.CoachId
            };

            unitOfWork.TeamRepository.Add(team);

            return Task.CompletedTask;
        }
    }
}
