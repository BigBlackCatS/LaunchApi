using LaunchApi.ApiClients.v1;
using LaunchApi.Domain.Models;

namespace LaunchApi.Services
{
    public class LaunchesService : ILaunchesService
    {
        public readonly ILaunchesApiClient _launchApiClient;
        public LaunchesService(ILaunchesApiClient launchApiClient)
        {
            _launchApiClient= launchApiClient;
        }

        public async Task<PagedResult<Launch>> GetPastLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default)
        {
            return await _launchApiClient.GetPastLaunchesAsync(offset, limit, cancellationToken);
        }

        public async Task<PagedResult<Launch>> GetUpcomingLaunchesAsync(uint offset, uint limit, CancellationToken cancellationToken = default)
        {
            return await _launchApiClient.GetUpcomingLaunchesAsync(offset, limit, cancellationToken);
        }

        public async Task<Launch> GetLaunchAsync(string id, CancellationToken cancellationToken = default)
        {
            if (id.Equals(string.Empty))
            {
                throw new ArgumentNullException(nameof(id), "The flight number can't be empty.");
            }

            return await _launchApiClient.GetLaunchAsync(id, cancellationToken);
        }
    }
}
