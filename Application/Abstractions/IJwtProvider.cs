﻿using Domain.Entities;
using System.Security.Claims;

namespace Application.Abstractions
{
    public interface IJwtProvider
    {
        public string GetAccessToken(ApplicationUser user, string userRole);

        public (string Token, int ValidDays) GetRefreshToken();

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    }
}
