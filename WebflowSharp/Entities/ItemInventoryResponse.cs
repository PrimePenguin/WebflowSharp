using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class ItemInventoryResponse
    {
        /// <summary>
        /// Unique identifier for a SKU item
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Total quantity of items remaining in inventory (if finite)
        /// </summary>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// infinite or finite
        /// </summary>
        [JsonProperty("inventoryType")]
        public string InventoryType { get; set; }
    }
}
