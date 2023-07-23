using LaunchApi.SpaceXContracts.Transport.Models;
using Newtonsoft.Json;

namespace LaunchApi.SpaceXContracts.Transport.Requests
{
    public class GetPagedLaunchesRequest
    {
        [JsonProperty("query")]
        public Query Query { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }
    }
}
