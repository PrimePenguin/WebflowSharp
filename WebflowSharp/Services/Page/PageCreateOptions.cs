using Newtonsoft.Json;

namespace WebflowSharp
{
    public class PageCreateOptions : Parameterizable
    {
        [JsonProperty("published")]
        public bool? Published { get; set; }
    }
}
