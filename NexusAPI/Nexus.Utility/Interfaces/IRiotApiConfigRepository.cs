﻿using Nexus.Model.RiotApi;

namespace Nexus.Utility.Interfaces
{
    public interface IRiotApiConfigRepository
    {
        string GetPlatformRoute(Platform platform);
        string GetEndpointPath(Endpoint endpoint);
    }
}