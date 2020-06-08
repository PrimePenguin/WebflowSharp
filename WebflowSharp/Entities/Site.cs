using System;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class Site
    {
        /// <summary>
        /// 	Unique identifier for site
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// 	Date the site was created
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// 	Name given to site
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Slugified version of name
        /// </summary>
        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        /// <summary>
        /// Date site was last published
        /// </summary>
        [JsonProperty("lastPublished")]
        public DateTimeOffset LastPublished { get; set; }

        /// <summary>
        /// URL of a generated image for the given site
        /// </summary>
        [JsonProperty("previewUrl")]
        public Uri PreviewUrl { get; set; }

        /// <summary>
        /// 	Site timezone set under Site Settings
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }
    }
}
