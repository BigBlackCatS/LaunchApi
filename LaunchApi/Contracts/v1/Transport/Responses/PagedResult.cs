namespace LaunchApi.Contracts.v1.Transport.Responses
{
    public class PagedResult<T>
    {
        public uint PageNumber { get; set; }

        public uint PageSize { get; set; }

        public uint Total { get; set; }

        public IEnumerable<T> Items { get; set; }

        public uint TotalPages => Total / PageSize + (Total % PageSize == 0 ? 0u : 1u);

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
