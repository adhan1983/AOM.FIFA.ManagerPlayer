using System;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Utils;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class HttpClientFactoryServiceExtension
    {
        public static IServiceCollection AddingHttpClientFactory(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddHttpClient(configuration.GetValue<string>(ApiConstants.FIFAClient), config => 
            {
                config.BaseAddress = new Uri(configuration.GetValue<string>(ApiConstants.BaseAddress));
                config.Timeout = new TimeSpan(0, 0, 30);
                config.DefaultRequestHeaders.Clear();
            });

            services.AddSingleton<IFIFAGatewayConfig, FIFAGatewayConfig>(scope =>
            {
                FIFAGatewayConfig gatewayConfig = new FIFAGatewayConfig();

                gatewayConfig.FIFAApiKey = configuration.GetValue<string>(ApiConstants.FIFAApiKey);
                gatewayConfig.FIFAApiToken = configuration.GetValue<string>(ApiConstants.FIFAApiToken);
                gatewayConfig.FIFAClient = configuration.GetValue<string>(ApiConstants.FIFAClient);

                return gatewayConfig;
            });

            services.AddScoped<IHttpClientFactoryService, HttpClientFactoryService>();

            return services;
        }
    }
}
