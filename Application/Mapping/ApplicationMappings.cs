using Application.Features.Clubs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public static class ApplicationMappings
    {
        public static void ConfigureAutoMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AddTeamClubCommand, Club>()
                .ForMember(x => x.Id, act => act.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Team, act => act.Ignore());
        }
    }
}
