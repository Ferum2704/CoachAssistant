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
        }
    }
}
