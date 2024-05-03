using CoachAssistant.Client.Entities;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Services.Abstractions
{
    public interface ICurrentTeamProvider
    {
        public ClubViewEntity CurrentClub {  get; set; }

        public void Set(ClubViewModel club);
    }
}
