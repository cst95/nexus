namespace Summoner.Models.RiotApi
{
    public class RepositoryResponse<T> where T: class
    {
        public T Item { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}