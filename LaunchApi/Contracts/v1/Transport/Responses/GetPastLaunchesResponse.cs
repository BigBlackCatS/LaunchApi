using LaunchApi.Contracts.v1.Transport.Models;

namespace LaunchApi.Contracts.v1.Transport.Responses
{
    public class GetPastLaunchesResponse
    {
        public IEnumerable<Launch> Launches { get; set; }
    }
}
