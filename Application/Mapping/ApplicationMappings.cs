using AutoMapper;
using CoachAssistant.Shared.Models;
using CoachAssistant.Shared.ViewModels;
using Domain.Entities;

namespace Application.Mapping
{
    public static class ApplicationMappings
    {
        public static void ConfigureAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TeamClubModel, Club>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Team, act => act.Ignore());
            cfg.CreateMap<Club, ClubViewModel>();
            cfg.CreateMap<Team, TeamViewModel>();
            cfg.CreateMap<Player, PlayerViewModel>();
            cfg.CreateMap<TrainingModel, Training>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartTime.HasValue ?
                        src.StartDate.Add(src.StartTime.Value) : src.StartDate))
                .ForMember(x => x.Team, act => act.Ignore())
                .ForMember(x => x.Players, act => act.Ignore())
                .ForMember(x => x.TrainingRecords, act => act.Ignore());
            cfg.CreateMap<Training, TrainingViewModel>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartDate.TimeOfDay));
            cfg.CreateMap<TrainingRecord, TrainingRecordViewModel>();
            cfg.CreateMap<TrainingMark, TrainingMarkViewModel>();
            cfg.CreateMap<TrainingMarkModel, TrainingMark>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Criterion, act => act.Ignore())
                .ForMember(x => x.TrainingRecord, act => act.Ignore());

            cfg.CreateMap<TournamentModel, Tournament>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.TournamentTeams, act => act.Ignore())
                .ForMember(x => x.Teams, act => act.Ignore())
                .ForMember(x => x.Matches, act => act.Ignore());
            cfg.CreateMap<Tournament, TournamentViewModel>();

            cfg.CreateMap<TournamentTeamModel, TournamentTeam>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Tournament, act => act.Ignore())
                .ForMember(x => x.Team, act => act.Ignore());
            cfg.CreateMap<TournamentTeam, TournamentTeamViewModel>();

            cfg.CreateMap<Match, MatchViewModel>()
                .ForMember(x => x.Tournament, act => act.Ignore());

            cfg.CreateMap<MatchTeam, MatchTeamViewModel>();
            cfg.CreateMap<MatchLineupPosition, MatchLineupPositionViewModel>()
                .ForMember(x => x.Position, act => act.Ignore());
            cfg.CreateMap<MatchLineupPositionPlayer,  MatchLineupPositionPlayerViewModel>()
                .ForMember(x => x.Player, act => act.Ignore());
            cfg.CreateMap<MatchLineupPositionPlayerModel, MatchLineupPositionPlayer>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Player, act => act.Ignore())
                .ForMember(x => x.Score, act => act.MapFrom(x => 1));

            cfg.CreateMap<PositionModel, Position>();
            cfg.CreateMap<Position, PositionViewModel>()
                .ForMember(x => x.Criteria, act => act.MapFrom(x => x.PositionCriteria));
            cfg.CreateMap<CriterionModel, Criterion>();
            cfg.CreateMap<Criterion, CriterionViewModel>();
            cfg.CreateMap<PositionCriteriaModel, PositionCriteria>();
            cfg.CreateMap<PositionCriteria, PositionCriteriaViewModel>();

            cfg.CreateMap<ActionTypeModel, ActionType>();
            cfg.CreateMap<ActionType, ActionTypeViewModel>();
            cfg.CreateMap<MatchPlayerActionModel, MatchPlayerAction>();
            cfg.CreateMap<MatchPlayerAction, MatchPlayerActionViewModel>();
        }
    }
}
