using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class Collection
    {
        /// <summary>
        /// The unique identifier for the Collection
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// 	Date Collection was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }

        /// <summary>
        /// 	Date Collection was created
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// 	Name given to Collection
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 	Slug of Collection in Site URL structure
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// 	The name of one Item in Collection (e.g. “post” if the Collection is called “Posts”)
        /// </summary>
        [JsonProperty("singularName")]
        public string SingularName { get; set; }

        [JsonProperty("fields")]
        public List<EntityField> Fields { get; set; }
    }

    public class Validations
    {
        [JsonProperty("singleLine", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SingleLine { get; set; }

        [JsonProperty("collectionId", NullValueHandling = NullValueHandling.Ignore)]
        public string CollectionId { get; set; }

        [JsonProperty("maxLength", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxLength { get; set; }

        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public Messages Messages { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public Pattern Pattern { get; set; }
    }

    public class Messages
    {
        [JsonProperty("maxLength")]
        public string MaxLength { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }
    }

    public class Pattern
    {
    }
}
