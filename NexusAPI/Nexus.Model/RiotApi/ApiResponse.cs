﻿﻿namespace Nexus.Model.RiotApi
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string ResponseBody { get; set; }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}