using Application.Features.Clubs;
using Application.Mapping;
using AutoMapper;
using CoachAssistant.Server.Api.Models;

namespace CoachAssistant.Server.Configurations
{
    internal static class AutoMapperConfiguration
    {
        private static MapperConfiguration configuration;

        public static IMapper ResolveMapper()
        {
            configuration ??= new MapperConfiguration(Configure);

            return configuration.CreateMapper();
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TeamClubModel, AddTeamClubCommand>();

            ApplicationMappings.ConfigureAutoMapper(cfg);
        }
    }
}
