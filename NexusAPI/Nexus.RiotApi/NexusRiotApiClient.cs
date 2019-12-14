using System.Text.Json;
using System.Threading.Tasks;
using Nexus.Model.Repository;
using Nexus.Model.RiotApi;
using Nexus.RiotApi.Interfaces;
using Nexus.Utility.Interfaces;

namespace Nexus.RiotApi
{
    public class NexusRiotApiClient : INexusRiotApiClient
    {
        private readonly IRiotApiClient _riotApiClient;
        private readonly IHttpResponseHandler _responseHandler;

        public NexusRiotApiClient(IRiotApiClient riotApiClient, IHttpResponseHandler responseHandler)
        {
            _riotApiClient = riotApiClient;
            _responseHandler = responseHandler;
        }

        public async Task<RepositoryResponse<T>> GetResponseAsync<T>(Platform platform, string summonerName) where T: class
        {
            var rawResponse = await _riotApiClient.GetResponseAsync(platform, Endpoint.GetSummonerByName, summonerName);
            var handledResponse = await  _responseHandler.HandleRiotApiResponseAsync(rawResponse);

            var response = new RepositoryResponse<T>()
            {
                Message = handledResponse.Message,
                Success = handledResponse.Success,
                ResponseType = handledResponse.ResponseType
            };

            try
            {
                response.Item = JsonSerializer.Deserialize<T>(handledResponse.ResponseBody, new JsonSerializerOptions(){ PropertyNameCaseInsensitive = true});
            }
            catch (JsonException)
            {
                response.Item = null;
            }

            return response;
        }
    }
}