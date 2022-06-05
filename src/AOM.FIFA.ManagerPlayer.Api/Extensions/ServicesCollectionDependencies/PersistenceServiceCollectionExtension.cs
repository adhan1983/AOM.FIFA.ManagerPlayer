using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using AOM.FIFA.ManagerPlayer.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Club.Repository;
using AOM.FIFA.ManagerPlayer.Persistence.League.Repository;
using AOM.FIFA.ManagerPlayer.Persistence.Nation.Repository;
using AOM.FIFA.ManagerPlayer.Persistence.Player.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class PersistenceServiceCollectionExtension
    {
        public static IServiceCollection AddingPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILeagueRepository, LeagueRepository>();
            services.AddScoped<IClubRepository, ClubRepository>();
            services.AddScoped<INationRepository, NationRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            return services;
        }
    }
}
