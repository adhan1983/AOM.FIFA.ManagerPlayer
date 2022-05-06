using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;
using Hangfire;
using System;

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
                bool applyMigrationFIFAHangFireDbContext = config.GetSection(ApiConstants.ApplyMigrationFIFAHangFireDbContext).Get<bool>();

                if (applyMigrationFIFADbContext)
                {
                    var fifaDbContext = scope.ServiceProvider.GetService<FIFAManagerPlayerDbContext>();
                    fifaDbContext.Database.Migrate();
                    //increase the timeout to run the migrations
                    //dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));                    
                }

                if (applyMigrationSyncFIFADbContext) 
                {
                    var fifaSyncDbContext = scope.ServiceProvider.GetService<FIFASynchronizationDbContext>();
                    fifaSyncDbContext.Database.Migrate();
                }

                var _syncService = scope.ServiceProvider.GetService<Application.Synchronization.Interfaces.ISyncService>();

                RecurringJob.AddOrUpdate(
                "FifaJob",
                () => _syncService.PublishingFifaJobs(),
                Cron.Minutely);                
               
            }
        }

    }

}
