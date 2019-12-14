﻿using System.Net.Http;
using System.Threading.Tasks;
 using Nexus.Model.RiotApi;

 namespace Nexus.Utility.Interfaces
{
    public interface IHttpResponseHandler
    {
        Task<ApiResponse> HandleRiotApiResponseAsync(HttpResponseMessage response);
    }
}