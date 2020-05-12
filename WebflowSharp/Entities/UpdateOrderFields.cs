using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class Fields
    {
        /// <summary>
        /// 	Arbitrary data for your records
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 	Company or method used to ship order
        /// </summary>
        [JsonProperty("shippingProvider")]
        public string ShippingProvider { get; set; }

        /// <summary>
        /// 	Tracking number for order shipment
        /// </summary>
        [JsonProperty("shippingTracking")]
        public string ShippingTracking { get; set; }
    }

    public class UpdateOrderFields
    {
        [JsonProperty("fields")]
        public Fields Fields { get; set; }
    }
}
