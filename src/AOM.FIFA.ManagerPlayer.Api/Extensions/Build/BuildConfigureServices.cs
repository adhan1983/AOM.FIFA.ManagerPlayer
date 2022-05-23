using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies;


namespace AOM.FIFA.ManagerPlayer.Api.Extensions.Build
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddGrpc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AOM.FIFA.ManagerPlayer.Api", Version = "v1" });
            });

            services.
                AddingApplicationDependencies().
                AddingHttpClientFactory(configuration).
                AddingPersistenceDependencies().
                //AddingHangFireDependencies(configuration).
                AddingDataBasesDependencies(configuration).
                AddingGRPCServiceCollectionDependencies().
                AddingLoggerServiceDependencies();

        }

    }
}
