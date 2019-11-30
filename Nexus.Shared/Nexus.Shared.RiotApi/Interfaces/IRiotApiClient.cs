using System.Net.Http;
using System.Threading.Tasks;
using Nexus.Shared.Models.RiotApi;

namespace Nexus.Shared.RiotApi.Interfaces
{
    public interface IRiotApiClient 
    {
        Task<HttpResponseMessage> GetResponseAsync(Platform platform, Endpoint endpoint, string identifier, string apiKey);
    }
}