﻿using System;
 using Nexus.Model.RiotApi;

namespace Nexus.Utility.Interfaces
{
    public interface IUriBuilderService
    {
        Uri GetUriForRequest(Platform platform, Endpoint endpoint, string identifier, string apiKey);
    }
}