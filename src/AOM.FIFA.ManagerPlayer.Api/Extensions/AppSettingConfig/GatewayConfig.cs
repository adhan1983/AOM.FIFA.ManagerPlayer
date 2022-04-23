using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Gateway.Utils;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.AppSettingConfig
{
    public static class GatewayConfig
    {
        public static IServiceCollection AddingGatewayConfigProperties(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFIFAGatewayConfig, FIFAGatewayConfig>(scope =>
            {
                FIFAGatewayConfig gatewayConfig = new FIFAGatewayConfig();

                gatewayConfig.FIFAApiKey = configuration.GetValue<string>(ApiConstants.FIFAApiKey);
                gatewayConfig.FIFAApiToken = configuration.GetValue<string>(ApiConstants.FIFAApiToken);

                return gatewayConfig;
            });

            return services;
        }
    }
}
