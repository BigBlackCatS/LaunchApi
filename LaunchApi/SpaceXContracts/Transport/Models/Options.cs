using Newtonsoft.Json;

namespace LaunchApi.SpaceXContracts.Transport.Models
{
    public class Options
    {
        [JsonProperty("offset")]
        public uint Offset { get; set; }

        [JsonProperty("limit")]
        public uint Limit { get; set; }

        [JsonProperty("sort")]
        public string OrderByField { get; set; }
    }
}
