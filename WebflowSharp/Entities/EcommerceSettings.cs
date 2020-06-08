using System;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class EcommerceSettings
    {
        /// <summary>
        /// 	Date that the site was created on
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// The id of the site being queried
        /// </summary>
        [JsonProperty("site")]
        public string Site { get; set; }

        /// <summary>
        /// 	The three-letter currency code of the site
        /// </summary>
        [JsonProperty("defaultCurrency")]
        public string DefaultCurrency { get; set; }
    }
}