using Application.Abstractions;
using Application.Abstractions.Lineup;
using Application.Abstractions.Topsis;
using Application.Services;
using Application.Services.IService;
using Application.Topsis;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<ICriterionService, CriterionService>();
            services.AddScoped<IPositionCriteriaService, PositionCriteriaService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ITrainingRecordService, TrainingRecordService>();
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IMatchService, MatchService>();

            services.AddScoped<ILineupCalculator, LineupCalculator>();
            services.AddScoped<ITopsisCalculator, TopsisCalculator>();
            services.AddScoped<IEstimationNormalizer, EstimationNormalizer>();
            services.AddScoped<ICriteriaWeightNormalizer, CriteriaWeightNormalizer>();
            services.AddScoped<IWeightedScoresCalculator, WeightedScoresCalculator>();

            services.AddScoped<ITournamentMatchesGenerator, TournamentMatchesGenerator>();

            return services;
        }
    }
}
