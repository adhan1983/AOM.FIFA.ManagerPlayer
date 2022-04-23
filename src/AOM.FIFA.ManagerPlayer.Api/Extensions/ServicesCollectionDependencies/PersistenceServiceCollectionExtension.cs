using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Repositories.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Persistence.SyncLeague.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class PersistenceServiceCollectionExtension
    {
        public static IServiceCollection AddingPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILeagueRepository, LeagueRepository>();

            return services;
        }
    }
}
