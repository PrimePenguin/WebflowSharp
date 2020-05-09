using Newtonsoft.Json;

namespace WebflowSharp
{
    public class ProductCreateOptions : Parameterizable
    {
        [JsonProperty("published")]
        public bool? Published { get; set; }
    }
}
