using System;
using System.Net.Http;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Extensions;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Services
{
    public class ClubService : IClubService
    {
        private readonly IFIFAGatewayConfig _fifaGatewayConfig;

        public ClubService(IFIFAGatewayConfig fifaGatewayConfig) => this._fifaGatewayConfig = fifaGatewayConfig;

        public async Task<ClubListResponse> GetClubsAsync(ClubRequest request)
        {
            var client = new HttpClient();

            string url = string.Concat("https://futdb.app/api/clubs?page=", request.Page, "&limit=", request.MaxItemPerPage);

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

                var result = await responseMessage.DeserializeResponseObj<ClubListResponse>();

                return result;
            }
        }
    }
}
