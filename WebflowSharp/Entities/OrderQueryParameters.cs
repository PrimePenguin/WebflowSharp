using Newtonsoft.Json;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Entities
{
    public class OrderQueryParameters : Parameterizable
    {
        /// <summary>
        /// Filter orders in one of the following statuses: <br>pending</br> <br>refunded</br> <br>dispute-lost</br> <br>fulfilled</br> <br>disputed</br> <br>unfulfilled</br>
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
