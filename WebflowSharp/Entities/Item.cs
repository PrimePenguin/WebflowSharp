using System;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class Item
    {
        /// <summary>
        /// 	Boolean determining if the Item is set to archived
        /// </summary>
        [JsonProperty("_archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// 	Boolean determining if the Item is set to draft
        /// </summary>
        [JsonProperty("_draft")]
        public bool Draft { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        /// <summary>
        /// 	Name given to the Item
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("post-body")]
        public string PostBody { get; set; }

        [JsonProperty("post-summary")]
        public string PostSummary { get; set; }

        [JsonProperty("thumbnail-image")]
        public Image ThumbnailImage { get; set; }

        [JsonProperty("main-image")]
        public Image MainImage { get; set; }

        /// <summary>
        /// 	URL structure of the Item in your site. Note: Updates to an item slug will break all links referencing the old slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// 	Date Item was last updated
        /// </summary>
        [JsonProperty("updated-on")]
        public DateTimeOffset UpdatedOn { get; set; }

        /// <summary>
        /// 	User who made last change to Item
        /// </summary>
        [JsonProperty("updated-by")]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// 	Date Item was created
        /// </summary>
        [JsonProperty("created-on")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// 	User who created Item
        /// </summary>
        [JsonProperty("created-by")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// 	Date Item was last published
        /// </summary>
        [JsonProperty("published-on")]
        public DateTimeOffset PublishedOn { get; set; }

        /// <summary>
        /// User who last published Item
        /// </summary>
        [JsonProperty("published-by")]
        public string PublishedBy { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// 	Unique identifier for the Collection the Item belongs within
        /// </summary>
        [JsonProperty("_cid")]
        public string CollectionId { get; set; }

        /// <summary>
        /// 	Unique identifier for the Item
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonIgnore]
        public ItemInventoryResponse Inventory { get; set; }

        [JsonIgnore]
        public string SiteId { get; set; }
    }

    public class Image
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
