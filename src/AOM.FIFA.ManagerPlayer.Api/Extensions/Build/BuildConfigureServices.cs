using AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://adhan-maldonado.us.auth0.com/";
                options.Audience = "https://fifamanager";
            });
            
            services.AddAuthorization();
            
            services.AddGrpc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AOM.FIFA.ManagerPlayer.Api", Version = "v1" });
            });

            services.
                AddingApplicationDependencies().                
                AddingPersistenceDependencies().                
                AddingDataBasesDependencies(configuration).
                AddingGRPCServiceCollectionDependencies().
                AddingLoggerServiceDependencies();

        }


    }
}
