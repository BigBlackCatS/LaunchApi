using LaunchApi.Domain.Models;

namespace LaunchApi.Services
{
    public interface ILaunchesService
    {
        Task<PagedResult<Launch>> GetPastLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default);

        Task<PagedResult<Launch>> GetUpcomingLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default);

        Task<Launch> GetLaunchAsync(string id, CancellationToken cancellationToken = default);
    }
}
