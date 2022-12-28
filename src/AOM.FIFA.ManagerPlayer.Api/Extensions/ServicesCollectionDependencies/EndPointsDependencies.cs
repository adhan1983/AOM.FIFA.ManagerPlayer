using AOM.FIFA.ManagerPlayer.gRPCServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class EndPointsDependencies
    {
        public static void AddingEndPointDependencies(this IApplicationBuilder app) 
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<LeaguegRPCService>();
                endpoints.MapGrpcService<NationgRPCService>();
                endpoints.MapGrpcService<PlayergRPCService>();
                endpoints.MapGrpcService<ClubgRPCService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
