using System.Text.Json;
using System.Threading.Tasks;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class RiotApiSummonerRepository : IRiotApiSummonerRepository
    {
        private readonly IRiotApiClient _riotApiClient;
        private readonly IHttpResponseHandler _responseHandler;

        public RiotApiSummonerRepository(IRiotApiClient riotApiClient, IHttpResponseHandler responseHandler)
        {
            _riotApiClient = riotApiClient;
            _responseHandler = responseHandler;
        }

        public async Task<RepositoryResponse<SummonerDto>> GetSummonerByNameAsync(Platform platform, string summonerName)
        {
            var rawResponse = await _riotApiClient.GetSummonerAsync(platform, Endpoint.GetSummonerByName, summonerName);
            var handledResponse = _responseHandler.HandleRiotApiResponse(rawResponse);

            var response = new RepositoryResponse<SummonerDto>()
            {
                Message = handledResponse.Message,
                Success = handledResponse.Success
            };

            try
            {
                response.Item = JsonSerializer.Deserialize<SummonerDto>(handledResponse.ResponseBody);
            }
            catch (JsonException)
            {
                response.Item = null;
            }

            return response;
        }
    }
}