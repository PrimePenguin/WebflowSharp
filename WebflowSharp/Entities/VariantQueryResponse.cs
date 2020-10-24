using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class VariantQueryResponse : BaseItemResponse
    {
        [JsonProperty("items")]
        public List<CollectionVariant> CollectionVariants { get; set; }
    }

    public class CollectionVariant
    {
        [JsonProperty("_archived")]
        public bool Archived { get; set; }

        [JsonProperty("_draft")]
        public bool Draft { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("compare-at-price")]
        public Price CompareAtPrice { get; set; }

        [JsonProperty("sku-values")]
        public Dictionary<string, string> SkuValues { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Width { get; set; }

        [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Length { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Height { get; set; }

        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Weight { get; set; }

        [JsonProperty("download-files")]
        public List<object> DownloadFiles { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("main-image")]
        public MainImage MainImage { get; set; }

        [JsonProperty("more-images")]
        public List<MainImage> MoreImages { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }

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

        [JsonProperty("_cid")]
        public string CollectionId { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ItemInventoryResponse Inventory { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SiteId { get; set; }
    }

    public class Price
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }

    public class MainImage
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("alt")]
        public string Alt { get; set; }
    }
}
