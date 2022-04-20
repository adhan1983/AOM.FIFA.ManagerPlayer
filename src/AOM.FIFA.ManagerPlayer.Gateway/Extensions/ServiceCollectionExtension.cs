using AOM.FIFA.ManagerPlayer.Gateway.Services;
using AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Gateway.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddingGatewayDependencies(this IServiceCollection services) 
        {
            services.AddScoped<ILeagueService, LeagueService>();

            return services;
        }
    }
}
