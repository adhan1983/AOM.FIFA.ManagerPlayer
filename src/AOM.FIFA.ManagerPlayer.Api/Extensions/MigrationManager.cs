﻿using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class MigrationManager
    {   
        public static void MigrateDatabase(this IApplicationBuilder app)
        {            
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var config = scope.ServiceProvider.GetService<IConfiguration>();

                bool applyMigration = config.GetSection(ApiConstants.ApplyMigration).Get<bool>();

                if (applyMigration)
                {
                    try
                    {
                        var dbContext = scope.ServiceProvider.GetService<FIFAManagerPlayerDbContext>();

                        //increase the timeout to run the migrations
                        //dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));

                        dbContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    } 
                }

            }
            
        }
    }
}