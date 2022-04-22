using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Repositoies.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.SyncLeague.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class PersistenceServiceCollectionExtension
    {
        public static IServiceCollection AddingPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILeagueRepository, LeagueRepository>();

            return services;
        }
    }
}
