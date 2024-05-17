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
            cfg.CreateMap<Club, ClubViewModel>()
                .ForMember(x => x.Team, act => act.Ignore());
            cfg.CreateMap<Team, TeamViewModel>();
            cfg.CreateMap<Player, PlayerViewModel>();
            cfg.CreateMap<TrainingModel, Training>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Team, act => act.Ignore())
                .ForMember(x => x.Players, act => act.Ignore())
                .ForMember(x => x.TrainingRecords, act => act.Ignore());
            cfg.CreateMap<Training, TrainingViewModel>();
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

            cfg.CreateMap<Match, MatchViewModel>();

            cfg.CreateMap<MatchTeam, MatchTeamViewModel>();

            cfg.CreateMap<PositionModel, Position>();
            cfg.CreateMap<Position, PositionViewModel>();
            cfg.CreateMap<CriterionModel, Criterion>();
            cfg.CreateMap<Criterion, CriterionViewModel>();
        }
    }
}
