using Nexus.Model.RiotApi;

namespace Nexus.Model.Repository
{
    public class RepositoryResponse<T> where T: class
    {
        public T Item { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
}