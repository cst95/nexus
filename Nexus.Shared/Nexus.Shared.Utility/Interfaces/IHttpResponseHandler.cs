using System.Net.Http;
using System.Threading.Tasks;
using Nexus.Shared.Models.RiotApi;

namespace Nexus.Shared.Utility.Interfaces
{
    public interface IHttpResponseHandler
    {
        Task<ApiResponse> HandleRiotApiResponseAsync(HttpResponseMessage response);
    }
}