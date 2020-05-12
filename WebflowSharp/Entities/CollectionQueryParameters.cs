using Newtonsoft.Json;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Entities
{
    public class CollectionQueryParameters : Parameterizable
    {
        /// <summary>
        /// 	Maximum number of orders to be returned (max limit: 100)
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Offset used for pagination if collection has more than limit orders
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
