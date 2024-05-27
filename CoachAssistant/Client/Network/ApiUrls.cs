namespace CoachAssistant.Client.Network
{
    public static class ApiUrls
    {
        private const string BaseUrl = "api/coaching-system";

        public static string LoginUrl => $"{BaseUrl}/identity/login";

        public static string RegisterUrl => $"{BaseUrl}/identity/register";

        public static string RevokeUrl => $"{BaseUrl}/identity/revoke";

        public static string TeamsUrl => $"{BaseUrl}/teams";

        public static string PlayersUrl => $"{BaseUrl}/teams/{{0}}/players";

        public static string CoachTeamUrl => $"{BaseUrl}/teams/coach";

        public static string TournamentsUrl => $"{BaseUrl}/tournaments";

        public static string MatchesUrl => $"{BaseUrl}/matchs";

        public static string CriteriaUrl => $"{BaseUrl}/criteria";

        public static string PositionsUrl => $"{BaseUrl}/positions";

        public static string MatchTeamsUrl => $"{BaseUrl}/matchTeams";

        public static string PositionCriteriaUrl => $"{BaseUrl}/positionCriteria";

        public static string GetPostPlayerUrl(Guid teamId) => string.Format(PlayersUrl, teamId);

        public static string GetTournamentByIdUrl(string tournamentId) => $"{TournamentsUrl}/{tournamentId}";

        public static string GetMatchesByTournamentIdUrl(string tournamentId) => $"{TournamentsUrl}/{tournamentId}/matches";

        public static string GetTeamTournamentsUrl(Guid teamdId) => $"{TournamentsUrl}?teamId={teamdId}";

        public static string GetMatchByIdUrl(string matchId) => $"{MatchesUrl}/{matchId}";

        public static string GetMatchTeamByIdUrl(Guid matchTeamId) => $"{MatchTeamsUrl}/{matchTeamId}";

        public static string GetPositionCriteriaByIdUrl(Guid positionCriterionId) => $"{PositionCriteriaUrl}/{positionCriterionId}";
    }
}
