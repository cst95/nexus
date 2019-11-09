using System.Net.Http;
using System.Threading.Tasks;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IRiotApiClient 
    {
        Task<HttpResponseMessage> GetSummonerAsync(Platform platform, Endpoint endpoint, string identifier);
    }
}