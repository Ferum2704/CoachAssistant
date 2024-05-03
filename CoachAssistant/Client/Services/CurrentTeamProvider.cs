using AutoMapper;
using CoachAssistant.Client.Entities;
using CoachAssistant.Client.Services.Abstractions;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services
{
    public class CurrentTeamProvider : ICurrentTeamProvider
    {
        private ClubViewEntity club;

        private readonly IMapper mapper;

        public ClubViewEntity CurrentClub
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

        public CurrentTeamProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Set(ClubViewModel club)
        {
            var currentClub = mapper.Map<ClubViewEntity>(club);

            CurrentClub = currentClub;
        }
    }
}
