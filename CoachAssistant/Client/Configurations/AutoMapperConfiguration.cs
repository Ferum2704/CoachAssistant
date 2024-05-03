using AutoMapper;
using CoachAssistant.Client.Entities;
using CoachAssistant.Shared.ViewModels;

namespace CoachAssistant.Client.Configurations
{
    public class AutoMapperConfiguration
    {
        private static MapperConfiguration configuration;

        public static IMapper ResolveMapper()
        {
            configuration ??= new MapperConfiguration(Configure);

            return configuration.CreateMapper();
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ClubViewModel, ClubViewEntity>();
        }
    }
}
