using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class UpdateItemInventoryFields
    {
        [JsonProperty("fields")]
        public UpdateInventoryFields UpdateInventoryFields { get; set; }
    }

    public class UpdateInventoryFields
    {
        /// <summary>
        /// Immediately sets quantity to this value
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 	Must be one of finite or infinite
        /// </summary>
        [JsonProperty("inventoryType")]
        public string InventoryType { get; set; }

        /// <summary>
        /// Adds this quantity to currently store quantity. Can be negative.
        /// </summary>
        [JsonProperty("updateQuantity")]
        public int? UpdateQuantity { get; set; }
    }
}
