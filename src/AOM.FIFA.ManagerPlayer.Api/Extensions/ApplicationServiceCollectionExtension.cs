using AOM.FIFA.ManagerPlayer.Application.League.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
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
