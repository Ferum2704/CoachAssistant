using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace CoachAssistant.Server.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection) =>
            connection.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
