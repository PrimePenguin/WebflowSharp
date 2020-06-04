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
        public UpdateInventoryFields()
        {
            InventoryType = "finite";
        }

        [JsonProperty("_id")]
        public string InventorId { get; set; }

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
    }
}
