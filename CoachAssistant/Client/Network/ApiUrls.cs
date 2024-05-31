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

        public static string TrainingMarksUrl => $"{BaseUrl}/trainingMarks";

        public static string TournamentTeamsUrl => $"{BaseUrl}/tournamentTeams";

        public static string PositionsPlayersUrl => $"{BaseUrl}/positionPlayers";

        public static string MatchPlayerActionsUrl => $"{BaseUrl}/playerActions";

        public static string ActionTypesUrl => $"{BaseUrl}/actionTypes";

        public static string TrainingRecordsUrl => $"{BaseUrl}/trainingRecords";

        public static string GetPlayersUrl(Guid teamId) => string.Format(PlayersUrl, teamId);

        public static string GetPlayerByIdUrl(Guid teamId, Guid playerId) => $"{string.Format(PlayersUrl, teamId)}/{playerId}";

        public static string GetPostPlayerUrl(Guid teamId) => string.Format(PlayersUrl, teamId);

        public static string GetTournamentByIdUrl(string tournamentId) => $"{TournamentsUrl}/{tournamentId}";

        public static string GetMatchesByTournamentIdUrl(string tournamentId) => $"{TournamentsUrl}/{tournamentId}/matches";

        public static string GetTeamTournamentsUrl(Guid teamdId) => $"{TournamentsUrl}?teamId={teamdId}";

        public static string GetMatchByIdUrl(string matchId) => $"{MatchesUrl}/{matchId}";

        public static string GetMatchTeamByIdUrl(Guid matchTeamId) => $"{MatchTeamsUrl}/{matchTeamId}";

        public static string GetPositionCriteriaByIdUrl(Guid positionCriterionId) => $"{PositionCriteriaUrl}/{positionCriterionId}";

        public static string GetTrainingsUrl(Guid teamId) => $"{TeamsUrl}/{teamId}/trainings";

        public static string GetTrainingByIdUrl(Guid teamId, Guid trainingId) => $"{TeamsUrl}/{teamId}/trainings/{trainingId}";

        public static string GetTrainingMarkByIdUrl(Guid trainingMarkId) => $"{TrainingMarksUrl}/{trainingMarkId}";

        public static string GetTournamentTeamsUrl(Guid tournamentId) => $"{TeamsUrl}?tournamentId={tournamentId}";

        public static string GetTournamentTeamByIdUrl(Guid tournamentTeamId) => $"{TournamentTeamsUrl}/{tournamentTeamId}";

        public static string GetLineupByMatchTeamIdUrl(Guid matchTeamId) => $"{MatchTeamsUrl}/{matchTeamId}/lineup";

        public static string GetRemovePlayersByPositionIdUrl(Guid positionId) => $"{PositionsPlayersUrl}?positionId={positionId}";

        public static string GetMatchPlayerActionByIdUrl(Guid playerActionId) => $"{MatchPlayerActionsUrl}/{playerActionId}";

        public static string GetPlayersByTeamIdUrl(Guid teamId) => $"{PlayersUrl}?teamId={teamId}";

        public static string GetTeamByIdUrl(Guid clubId) => $"{TeamsUrl}/{clubId}";

        public static string GetSendTeamForVerificationUrl(Guid clubId) => $"{GetTeamByIdUrl(clubId)}/verification/send";

        public static string GetAcceptTeamVerificationUrl(Guid clubId) => $"{GetTeamByIdUrl(clubId)}/verification/accept";

        public static string GetRejectTeamVerificationUrl(Guid clubId) => $"{GetTeamByIdUrl(clubId)}/verification/reject";

        public static string GetTrainingRecordByIdUrl(Guid recordId) => $"{TrainingRecordsUrl}/{recordId}";

        public static string GetTrainingRecordEmailUrl(Guid recordId) => $"{TrainingRecordsUrl}/{recordId}/email";
    }
}
