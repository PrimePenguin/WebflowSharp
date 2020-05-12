using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class EntityField
    {
        /// <summary>
        /// Unique identifier for the field
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 	Boolean determining if the Field can be edited (some fields are automatically created and cannot be edited)
        /// </summary>
        [JsonProperty("editable")]
        public bool Editable { get; set; }

        /// <summary>
        /// Determines if field is required
        /// </summary>
        [JsonProperty("required")]
        public bool FieldRequired { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 	Slug of the field in the URL structure of your site for template pages
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// 	Name given to the field
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("validations", NullValueHandling = NullValueHandling.Ignore)]
        public Validations Validations { get; set; }

        [JsonProperty("helpText", NullValueHandling = NullValueHandling.Ignore)]
        public string HelpText { get; set; }

        [JsonProperty("innerType", NullValueHandling = NullValueHandling.Ignore)]
        public string InnerType { get; set; }

        [JsonProperty("unique", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Unique { get; set; }

        [JsonProperty("default", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Default { get; set; }
    }
}
