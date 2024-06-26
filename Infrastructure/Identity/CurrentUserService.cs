﻿using Application.Abstractions;
using CoachAssistant.Shared;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public string CurrentUserUserName => httpContextAccessor.HttpContext?.User?.Identity?.Name ?? string.Empty;

        public Guid CurrentUserId => new(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public async Task<DomainUser> GetCurrentDomainUserAsync()
        {
            var user = await userManager.FindByNameAsync(CurrentUserUserName);

            return user.DomainUser;
        }

        public bool IsInRole(ApplicationUserRole applicationRole)
        {
            var user = httpContextAccessor.HttpContext.User;

            if (user == null)
            {
                return false;
            }

            return user.IsInRole(applicationRole.ToString());
        }
    }
}
