using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class BaseItemResponse
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
