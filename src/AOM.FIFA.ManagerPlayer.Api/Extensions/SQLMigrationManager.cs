using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class SQLMigrationManager
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();

                bool applyMigrationFIFADbContext = config.GetSection(ApiConstants.ApplyMigrationFIFADbContext).Get<bool>();
                bool applyMigrationSyncFIFADbContext = config.GetSection(ApiConstants.ApplyMigrationSyncFIFADbContext).Get<bool>();

                if (applyMigrationFIFADbContext)
                {
                    var fifaDbContext = scope.ServiceProvider.GetService<FIFAManagerPlayerDbContext>();
                    fifaDbContext.Database.Migrate();
                    //increase the timeout to run the migrations
                    //dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));                    
                }
                if (applyMigrationSyncFIFADbContext) 
                {
                    var fifaSyncDbContext = scope.ServiceProvider.GetService<FIFAManagerPlayerDbContext>();
                    fifaSyncDbContext.Database.Migrate();
                }

            }

        }

    }

}
