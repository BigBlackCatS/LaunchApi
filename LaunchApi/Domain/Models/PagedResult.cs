namespace LaunchApi.Domain.Models
{
    public class PagedResult<T>
    {
        public uint Offset { get; set; }

        public uint Limit { get; set; }

        public uint TotalDocs { get; set; }

        public IEnumerable<T> Docs { get; set; }

        public uint Page { get; set; }

        public uint TotalPages { get; set; }

        public bool HasPrevPage;

        public bool HasNextPage;
    }
}
