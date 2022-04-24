using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Application.League.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<ISyncLeagueService, SyncLeagueService>();

            return services;
        }
    }
}
