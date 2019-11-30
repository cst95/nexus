using System;
using Nexus.Shared.Models.RiotApi;

namespace Nexus.Shared.Utility.Interfaces
{
    public interface IUriBuilderService
    {
        Uri GetUriForRequest(Platform platform, Endpoint endpoint, string identifier, string apiKey);
    }
}