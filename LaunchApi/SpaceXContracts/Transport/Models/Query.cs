using Newtonsoft.Json;

namespace LaunchApi.SpaceXContracts.Transport.Models
{
    public class Query
    {
        [JsonProperty("upcoming")]
        public bool Upcoming { get; set; }
    }
}
