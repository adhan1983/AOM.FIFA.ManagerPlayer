using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
                    //UseKestrel(options =>
                    //{
                    //    var restSectionValue = config.GetSection("Ports").GetSection("REST").Value;
                    //    var gRpcSectionValue = config.GetSection("Ports").GetSection("GRPC").Value;

                    //    if (restSectionValue == null || !int.TryParse(restSectionValue, out var restPort))
                    //    {
                    //        restPort = 80;
                    //    }

                    //    if (gRpcSectionValue == null || !int.TryParse(gRpcSectionValue, out var gRpcPort))
                    //    {
                    //        gRpcPort = 81;
                    //    }
                    //    options.ListenAnyIP(restPort, listenOptions =>
                    //    {
                    //        listenOptions.Protocols = HttpProtocols.Http1;
                    //    });

                    //    options.ListenAnyIP(gRpcPort, listenOptions =>
                    //    {
                    //        listenOptions.Protocols = HttpProtocols.Http2;
                    //    });

                    //    options.Limits.MaxRequestBodySize = null;
                    //}); 
                });
    }
}
