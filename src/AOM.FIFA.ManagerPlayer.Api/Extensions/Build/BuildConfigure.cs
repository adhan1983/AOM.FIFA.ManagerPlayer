using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services;
using AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigure
    {        
        public static void Build(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AOM.FIFA.ManagerPlayer.Api v1"));
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AOM.FIFA.ManagerPlayer.Api Deploy v1"));

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();            
            app.UseAuthentication();
            app.UseAuthorization();            
            app.AddingEndPointDependencies();
            app.ApplyMigration();
        }
    }
}
