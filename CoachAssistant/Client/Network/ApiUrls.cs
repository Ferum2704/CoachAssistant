namespace CoachAssistant.Client.Network
{
    public static class ApiUrls
    {
        private const string BaseUrl = "api/coaching-system";

        public static string LoginUrl => $"{BaseUrl}/identity/login";

        public static string RegisterUrl => $"{BaseUrl}/identity/register";

        public static string PostTeamUrl => $"{BaseUrl}/team";
    }
}
