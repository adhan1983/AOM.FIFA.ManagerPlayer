using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace AOM.FIFA.ManagerPlayer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).
                Build().              
                Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration((context, config) => {

                        var buildCofiguration = config.Build();

                        string kvURL = buildCofiguration["FIFAMANAGERPLAYERKV:kvURL"];
                        string tenantId = buildCofiguration["FIFAMANAGERPLAYERKV:TenantId"];
                        string clientId = buildCofiguration["FIFAMANAGERPLAYERKV:ClientId"];
                        string clientSecret = buildCofiguration["FIFAMANAGERPLAYERKV:ClientSecret"];

                        var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
                        var client = new SecretClient(new System.Uri(kvURL), credentials);
                        config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());


                    });

                });
    }
}
