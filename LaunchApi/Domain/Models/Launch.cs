using Newtonsoft.Json;

namespace LaunchApi.Domain.Models
{
    public class Launch
    {
        public string Id { get; set; }

        [JsonProperty("flight_number")]
        public long FlightNumber { get; set; }

        public string Name { get; set; }

        public Links Links { get; set; }

        [JsonProperty("date_utc")]
        public DateTime? FireDateUtc { get; set; }

        [JsonProperty("date_local")]
        public DateTime? DateLocalUtc { get; set; }

        public string Details { get; set; }
    }
}
