using Newtonsoft.Json;

namespace WebflowSharp.Entities
{
    public class BaseCollectionModel
    {
        /// <summary>
        /// The unique identifier for the Collection
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// 	Date Collection was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// 	Date Collection was created
        /// </summary>
        [JsonProperty("createdOn")]
        public string CreatedOn { get; set; }

        /// <summary>
        ///  The unique identifier for the Collection
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///	Slug of Collection
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// 	The name of one Item in Collection (e.g. “post” if the Collection is called “Posts”)
        /// </summary>
        [JsonProperty("singularName")]
        public string SingularName { get; set; }
    }

    public class ProductsCollectionModel : BaseCollectionModel
    {
    }

    public class SkusCollectionModel : BaseCollectionModel
    {
    }

    public class CategoriesCollectionModel : BaseCollectionModel
    {
    }
}
