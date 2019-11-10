using System.Net.Http;
using System.Threading.Tasks;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IHttpResponseHandler
    {
        Task<ApiResponse> HandleRiotApiResponseAsync(HttpResponseMessage response);
    }
}