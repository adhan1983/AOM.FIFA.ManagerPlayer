using AOM.FIFA.ManagerPlayer.Gateway.Services;
using AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class GatewayServiceCollectionExtension
    {
        public static IServiceCollection AddingGatewayDependencies(this IServiceCollection services) 
        {
            services.AddScoped<ILeagueService, LeagueService>();
            services.AddScoped<IClubService, ClubService>();

            return services;
        }
    }
}
