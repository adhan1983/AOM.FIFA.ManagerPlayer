using AOM.FIFA.ManagerPlayer.gRPCServer.Services;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class GRPCServiceCollectionDependencies
    {
        public static IServiceCollection AddingGRPCServiceCollectionDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILeaguegRPCService, LeaguegRPCService>();
            services.AddScoped<IClubgRPCService, ClubgRPCService>();
            services.AddScoped<INationgRPCService, NationgRPCService>();
            services.AddScoped<IPlayergRPCService, PlayergRPCService>();            

            return services;
        }
    }
}
