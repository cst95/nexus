using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Nexus.Shared.Models.RiotApi;
using Microsoft.Extensions.Logging;
using Nexus.Shared.Utility.Interfaces;

namespace Nexus.Shared.Utility
{
    public class HttpResponseHandler : IHttpResponseHandler
    {
        private readonly ILogger<HttpResponseHandler> _logger;

        public HttpResponseHandler(ILogger<HttpResponseHandler> logger)
        {
            _logger = logger;
        }
        
        public async Task<ApiResponse> HandleRiotApiResponseAsync(HttpResponseMessage response)
        {
            var responseType = GetResponseType(response);

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _logger.LogError("Riot Games API key has expired.");
            }
            
            return new ApiResponse
            {
                Success = responseType == ResponseType.Ok,
                ResponseType = GetResponseType(response),
                ResponseBody = await response.Content.ReadAsStringAsync(),
                Message = GetMessage(responseType)
            };
        }

        private ResponseType GetResponseType(HttpResponseMessage response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => ResponseType.Ok,
                HttpStatusCode.NotFound => ResponseType.NotFound,
                _ => ResponseType.Error
            };
        }
        
        private string GetMessage(ResponseType responseType)
        {
            return responseType switch
            {
                ResponseType.Ok => string.Empty,
                ResponseType.NotFound => "Summoner not found.",
                _ => "Something went wrong."
            };
        }
    }
}