﻿using Nexus.Shared.Models.RiotApi;

 namespace Nexus.Shared.Models.Repository
{
    internal class RepositoryResponse<T> where T: class
    {
        public T Item { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}