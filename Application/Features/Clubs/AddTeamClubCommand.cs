using MediatR;

namespace Application.Features.Clubs
{
    public class AddTeamClubCommand : IRequest
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Stadium { get; set; }

        public Guid CoachId { get; set; }
    }
}
