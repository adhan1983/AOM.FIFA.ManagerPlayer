using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

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
                    webBuilder.ConfigureKestrel(options => 
                    {
                        //options.ListenAnyIP(5000);
                        //options.ListenAnyIP(5001, listenOptions =>
                        //{
                        //    listenOptions.Protocols = HttpProtocols.Http2;
                        //});

                        //options.ListenAnyIP(5000, listenOptions =>
                        //{
                        //    listenOptions.Protocols = HttpProtocols.Http1;
                        //});

                        //options.ListenAnyIP(5001, listenOptions =>
                        //{
                        //    listenOptions.Protocols = HttpProtocols.Http2;
                        //});

                        //options.Limits.MaxRequestBodySize = null;
                    });

                });
    }
}
