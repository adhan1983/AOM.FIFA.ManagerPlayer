using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Api.Extensions.Build;
using Hangfire;

namespace AOM.FIFA.ManagerPlayer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) => services.Build(Configuration);

        //IBackgroundJobClient backgroundJobs
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.Build(env);
        
    }
}
