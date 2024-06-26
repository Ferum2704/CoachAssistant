﻿using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Server.Hubs
{
    public interface INotificationsClient
    {
        Task HelloNotification(string message);

        Task TeamAddedNotification(ClubViewModel club);

        Task PlayerAddedNotification(PlayerViewModel player);

        Task TrainingAddedNotification(TrainingViewModel training);

        Task PositionAddedNotification(PositionViewModel position);

        Task CriterionAddedNotification(CriterionViewModel criterion);

        Task PositionCriteriaAddedNotification(PositionCriteriaViewModel positionCriteria);

        Task TournamentAddedNotification(TournamentViewModel tournament);

        Task TournamentTeamAddedNotification(TournamentTeamViewModel tournamentTeam);

        Task TrainingMarkAddedNotification(TrainingMarkViewModel trainingMark);

        Task MatchPlayerActionAddedNotification(MatchPlayerActionViewModel matchPlayerAction);
    }
}
