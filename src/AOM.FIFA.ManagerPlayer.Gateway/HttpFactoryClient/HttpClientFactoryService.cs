using AOM.FIFA.ManagerPlayer.Gateway.Extensions;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Player;
using AOM.FIFA.ManagerPlayer.Gateway.Utils.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFIFAGatewayConfig _fifaGatewayConfig;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory, IFIFAGatewayConfig fifaGatewayConfig)
        {
            _httpClientFactory = httpClientFactory;
            _fifaGatewayConfig = fifaGatewayConfig;
        }
        public async Task<LeagueListResponse> GetLeaguesAsync(Request request)
        {
            string urlLeague = "/leagues?page=";

            return await SendRequestAsync<LeagueListResponse>(request, urlLeague);
        }

        public async Task<ClubListResponse> GetClubsAsync(Request request)
        {
            string urlLeague = "/clubs?page=";

            return await SendRequestAsync<ClubListResponse>(request, urlLeague);
        }

        public async Task<PlayerListResponse> GetPlayersAsync(Request request)
        {
            string urlLeague = "/players?page=";

            return await SendRequestAsync<PlayerListResponse>(request, urlLeague);
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(Request request, string url) where TResponse : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(_fifaGatewayConfig.FIFAClient))
            {
                string urlRequest = string.Concat(httpClient.BaseAddress, url, request.Page, "&limit=", request.MaxItemPerPage);

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(urlRequest),
                    Headers =
                    {
                        { _fifaGatewayConfig.FIFAApiKey , _fifaGatewayConfig.FIFAApiToken },
                    },
                };

                using (var response = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
                {
                    var responseMessage = response.EnsureSuccessStatusCode();

                    var result = await responseMessage.DeserializeResponseObj<TResponse>();

                    return result;
                }
            }

        }

    }
}
