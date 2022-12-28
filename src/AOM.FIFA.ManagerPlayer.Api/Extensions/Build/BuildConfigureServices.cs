using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies;
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

            
            
            services.AddGrpc();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(ApiConstants.SwaggerVersionV1, new OpenApiInfo { Title = ApiConstants.SwaggerTitle, Version = ApiConstants.SwaggerVersionV1 });

                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });

            services.AddingAuthenticationDependencies(configuration);            

            services.
                AddingApplicationDependencies().
                AddingPersistenceDependencies().
                AddingDataBasesDependencies(configuration).
                AddingGRPCServiceCollectionDependencies().
                AddingLoggerServiceDependencies();
           
        }

    }
}
