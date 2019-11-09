using System.Net.Http;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public interface IHttpResponseHandler
    {
        ApiResponse HandleRiotApiResponse(HttpResponseMessage response);
    }
}