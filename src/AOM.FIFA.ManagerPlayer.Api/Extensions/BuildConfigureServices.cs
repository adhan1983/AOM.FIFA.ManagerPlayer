using AOM.FIFA.ManagerPlayer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;




namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class BuildConfigureServices
    {
        public static void Build(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddControllers();

            services.AddDbContext<FIFAManagerPlayerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString")));
            

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
