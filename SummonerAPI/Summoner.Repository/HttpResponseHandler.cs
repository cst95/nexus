using System.Net;
using System.Net.Http;
using Summoner.Models.RiotApi;

namespace Summoner.Repository
{
    public class HttpResponseHandler : IHttpResponseHandler
    {
        public ApiResponse HandleRiotApiResponse(HttpResponseMessage response)
        {
            var responseType = GetResponseType(response);

            return new ApiResponse
            {
                Success = responseType == ResponseType.Ok,
                ResponseType = GetResponseType(response),
                ResponseBody = response.ToString(),
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