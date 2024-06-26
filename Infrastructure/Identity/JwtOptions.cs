﻿namespace Infrastructure.Identity
{
    public class JwtOptions
    {
        public string Issuer { get; init; }

        public string Audience { get; init; }

        public string SecretKey { get; init; }

        public int AccessTokenExpirationTimeInMinutes { get; init; }

        public int RefreshTokenExpirationTimeInDays { get; init; }
    }
}
