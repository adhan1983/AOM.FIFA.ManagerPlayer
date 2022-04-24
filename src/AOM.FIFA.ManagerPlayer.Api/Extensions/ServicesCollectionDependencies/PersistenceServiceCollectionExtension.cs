using AOM.FIFA.ManagerPlayer.Persistence.Base;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.League.Repository;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class PersistenceServiceCollectionExtension
    {
        public static IServiceCollection AddingPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILeagueRepository, LeagueRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();

            return services;
        }
    }
}
