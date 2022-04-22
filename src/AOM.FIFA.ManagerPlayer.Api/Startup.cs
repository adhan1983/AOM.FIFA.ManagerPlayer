using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFA.ManagerPlayer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;        

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services) => services.Build();        
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.Build(env);
        
    }
}
