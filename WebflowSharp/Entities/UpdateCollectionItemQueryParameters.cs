using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class UpdateCollectionItemQueryParameters
    {
        [JsonProperty("fields")]
        public CollectionItemFields Fields { get; set; }
    }

    public class CollectionItemFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("_archived")]
        public bool Archived { get; set; }

        [JsonProperty("_draft")]
        public bool Draft { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("post-body")]
        public string PostBody { get; set; }

        [JsonProperty("post-summary")]
        public string PostSummary { get; set; }

        [JsonProperty("main-image")]
        public string MainImage { get; set; }
    }
}
