using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationDependencies(this IServiceCollection services)
        {

            services.AddScoped<INationService, NationService>();
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IPlayerService, PlayerService>();

            return services;
        }
    }
}
