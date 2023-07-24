using Newtonsoft.Json;

namespace LaunchApi.Domain.Models
{
    public class Links
    {
        public Patch Patch { get; set; }

        public Flickr Flickr { get; set; }

        public Reddit Reddit { get; set; }

        public string Presskit { get; set; }

        public string Webcast { get; set; }

        public string Article { get; set; }

        public string Wikipedia { get; set; }

        [JsonProperty("youtube_id")]
        public string YouTubeId { get; set; }
    }
}
