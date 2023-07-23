using LaunchApi.Contracts.v1.Transport.Models;

namespace LaunchApi.Contracts.v1.Transport.Responses
{
    public class GetUpcomingLaunchesResponse
    {
        public IEnumerable<Launch> Launches { get; set; }
    }
}
