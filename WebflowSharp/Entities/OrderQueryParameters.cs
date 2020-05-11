using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class OrderQueryParameters
    {
        /// <summary>
        /// Filter orders in one of the following statuses: pending, refunded, dispute-lost, fulfilled, disputed, unfulfilled.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

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
