using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class AuthInfo
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("grantType")]
        public string GrantType { get; set; }

        [JsonProperty("lastUsed")]
        public DateTimeOffset LastUsed { get; set; }

        [JsonProperty("sites")]
        public List<string> Sites { get; set; }

        [JsonProperty("orgs")]
        public List<string> Orgs { get; set; }

        [JsonProperty("users")]
        public List<string> Users { get; set; }

        [JsonProperty("rateLimit")]
        public long RateLimit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }
    }

    public class Application
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("ownerType")]
        public string OwnerType { get; set; }
    }
}
