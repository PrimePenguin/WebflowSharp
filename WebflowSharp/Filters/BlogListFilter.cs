using Newtonsoft.Json;

namespace WebflowSharp.Filters
{
    public class BlogListFilter : ListFilter<Blog>
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }
    }
}