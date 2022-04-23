using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Persistence.Context;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class DatabasesDependencies
    {
        public static IServiceCollection AddingDataBasesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FIFAManagerPlayerDbContext>(options =>
                     options.
                     UseSqlServer(configuration.GetConnectionString(ApiConstants.SqlConnectionString)));

            return services;
        }
    }
}
