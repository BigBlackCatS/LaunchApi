using Newtonsoft.Json;

namespace LaunchApi.Contracts.v1.Transport.Models
{
    public class Launch
    {
        public string Id { get; set; }

        public long FlightNumber { get; set; }

        public string Name { get; set; }

        public Links Links { get; set; }

        public DateTime? FireDateUtc { get; set; }

        public DateTime? DateLocalUtc { get; set; }

        public string Details { get; set; }
    }
}
