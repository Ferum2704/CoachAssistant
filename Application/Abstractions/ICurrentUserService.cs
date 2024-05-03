using CoachAssistant.Shared;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICurrentUserService
    {
        string CurrentUserUserName { get; }

        Guid CurrentUserId { get; }

        bool IsInRole(ApplicationUserRole applicationRole);

        Task<DomainUser> GetCurrentDomainUserAsync();
    }
}
