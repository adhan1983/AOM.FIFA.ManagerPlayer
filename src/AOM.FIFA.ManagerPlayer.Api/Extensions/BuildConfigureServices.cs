using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services) 
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AOM.FIFA.ManagerPlayer.Api", Version = "v1" });
            });

            services.
                AddingApplicationDependencies().
                AddingGatewayDependencies().
                AddingPersistenceDependencies();
        }
    }
}
