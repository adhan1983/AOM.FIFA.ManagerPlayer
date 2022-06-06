using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class DatabasesDependencies
    {
        public static IServiceCollection AddingDataBasesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FIFAManagerPlayerDbContext>(options =>
                     options.
                     UseSqlServer(configuration.GetConnectionString(ApiConstants.PlayerSqlConnectionString)));            
            

            return services;
        }
    }
}
