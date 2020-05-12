using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class ItemQueryResponse
    {
        /// <summary>
        /// 	List of Items within the Collection
        /// </summary>
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        /// <summary>
        /// 	Number of items returned
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }

        /// <summary>
        /// 	The limit specified in the request (default: 100)
        /// </summary>
        [JsonProperty("limit")]
        public long Limit { get; set; }

        /// <summary>
        /// The offset specified for pagination (default: 0)
        /// </summary>
        [JsonProperty("offset")]
        public long Offset { get; set; }

        /// <summary>
        /// Total number of items in the collection
        /// </summary>
        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
