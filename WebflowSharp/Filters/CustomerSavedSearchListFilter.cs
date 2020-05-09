using Newtonsoft.Json;

namespace WebflowSharp.Filters
{
    public class CustomerSavedSearchListFilter : ListFilter<CustomerSavedSearch>
    {
        /// <summary>
        /// Restrict results to after the specified ID.
        /// </summary>
        [JsonProperty("since_id")]
        public long? SinceId { get; set; }
    }
}