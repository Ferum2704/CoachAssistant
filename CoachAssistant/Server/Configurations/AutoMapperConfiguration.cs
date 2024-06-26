﻿using Application.Mapping;
using AutoMapper;

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
            ApplicationMappings.ConfigureAutoMapper(cfg);
        }
    }
}
