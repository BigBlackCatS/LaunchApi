using LaunchApi.Domain.Models;

namespace LaunchApi.ApiClients.v1
{
    public interface ILaunchesApiClient
    {
        Task<PagedResult<Launch>> GetPastLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default);

        Task<PagedResult<Launch>> GetUpcomingLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default);

        Task<Launch> GetLaunchAsync(string id, CancellationToken cancellationToken = default);
    }
}
