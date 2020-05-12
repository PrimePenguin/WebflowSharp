using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class CreateWebhookRequest
    {
        /// <summary>
        /// 	Unique identifier for the site
        /// </summary>
        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        /// <summary>
        /// Which action the webhook is listening for
        /// </summary>
        [JsonProperty("triggerType")]
        public FilterType TriggerType { get; set; }

        /// <summary>
        /// 	The https URL on your server the webhook will send a request to when the webhook is triggered
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Optional filter for selecting which events you want webhooks to be triggered for.
        /// </summary>
        [JsonProperty("filter")]
        public string Filter { get; set; }
    }
}
