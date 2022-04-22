using System;
using System.Net.Http;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Extensions;
using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IFIFAGatewayConfig _fifaGatewayConfig;

        public LeagueService(IFIFAGatewayConfig fifaGatewayConfig) => this._fifaGatewayConfig = fifaGatewayConfig;
        
        public async Task<LeagueListResponse> GetLeaguesAsync(LeagueRequest request)
        {
            var client = new HttpClient();

            string url = string.Concat("https://futdb.app/api/leagues?page=", request.Page, "&limit=", request.MaxItemPerPage);
            
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { _fifaGatewayConfig.FIFAApiKey , _fifaGatewayConfig.FIFAApiToken },
                },
            };

            using (var response = await client.SendAsync(requestMessage))
            {
                var responseMessage = response.EnsureSuccessStatusCode();

                var result = await  responseMessage.DeserializeResponseObj<LeagueListResponse>();

                return result;
            }
        }
    }
}
