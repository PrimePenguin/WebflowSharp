using System;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class WebhookModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("triggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("triggerId")]
        public string TriggerId { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("lastUsed")]
        public DateTimeOffset LastUsed { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
