using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncNation.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncNation.Services;

using AOM.FIFA.ManagerPlayer.Application.Club.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationDependencies(this IServiceCollection services)
        {

            //services.AddScoped<INationService, NationService>();
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IClubService, ClubService>();            
            
            services.AddScoped<ISyncLeagueService, SyncLeagueService>();
            services.AddScoped<ISyncNationService, SyncNationService>();

            services.AddScoped<ISyncService, SyncService>();
            services.AddScoped<ISyncClubService, SyncClubService>();
            services.AddScoped<ISyncPlayerService, SyncPlayerService>();

            return services;
        }
    }
}
