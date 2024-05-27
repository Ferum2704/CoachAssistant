using AutoMapper;
using CoachAssistant.Client.Services.Abstractions;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class CurrentTeamProvider : ICurrentTeamProvider
    {
        private ClubViewModel club;

        private readonly IMapper mapper;

        public ClubViewModel CurrentClub
        {
            get => club;
            set
            {
                if (club is null || value is null)
                {
                    club = value;
                }
            }
        }
    }
}
