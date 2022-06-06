using AOM.FIFA.ManagerPlayer.Logging.Interfaces;
using AOM.FIFA.ManagerPlayer.Logging.Service;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.IO;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class LoggingServiceCollectionDependencies
    {
        public static IServiceCollection AddingLoggerServiceDependencies(this IServiceCollection services)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }
    }
}
