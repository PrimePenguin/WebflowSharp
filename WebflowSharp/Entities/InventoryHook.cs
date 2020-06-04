using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class InventoryHook
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("inventoryType")]
        public string InventoryType { get; set; }
    }
}
