using AOM.FIFA.ManagerPlayer.Application.League.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<ISyncLeagueService, SyncLeagueService>();

            return services;
        }
    }
}
