using AOM.FIFA.ManagerPlayer.Gateway.Utils;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Extensions;

namespace AOM.FIFA.ManagerPlayer.Gateway.Services
{
    public class LeagueService : ILeagueService
    {
        public async Task<LeagueListResponse> GetLeaguesAsync(LeagueRequest request)
        {
            var client = new HttpClient();

            string url = string.Concat("https://futdb.app/api/leagues?page=", request.Page, "&limit=", request.MaxItemPerPage);

            string token = "e989438f-931f-482b-b5fa-25dd62f2ca98";

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { GatewayConstants.FIFAApiKey , token },
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
