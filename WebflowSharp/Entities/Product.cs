using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class ProductQueryResponse: BaseItemResponse
    {
        [JsonProperty("items")]
        public List<CollectionProduct> CollectionProducts { get; set; }
    }

    public class CollectionProduct
    {
        [JsonProperty("shippable")]
        public bool Shippable { get; set; }

        [JsonProperty("tax-category")]
        public string TaxCategory { get; set; }

        [JsonProperty("_archived")]
        public bool Archived { get; set; }

        [JsonProperty("_draft")]
        public bool Draft { get; set; }

        [JsonProperty("sku-properties")]
        public List<SkuProperty> SkuProperties { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("updated-on")]
        public DateTimeOffset? UpdatedOn { get; set; }

        [JsonProperty("updated-by")]
        public string UpdatedBy { get; set; }

        [JsonProperty("created-on")]
        public DateTimeOffset? CreatedOn { get; set; }

        [JsonProperty("created-by")]
        public string CreatedBy { get; set; }

        [JsonProperty("published-on")]
        public DateTimeOffset? PublishedOn { get; set; }

        [JsonProperty("published-by")]
        public string PublishedBy { get; set; }

        [JsonProperty("default-sku")]
        public string DefaultSku { get; set; }

        [JsonProperty("_cid")]
        public string CollectionId { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Category { get; set; }

        [JsonIgnore]
        public string SiteId { get; set; }
    }

    public class SkuProperty
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("enum")]
        public List<Enum> Enum { get; set; }
    }

    public class Enum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
