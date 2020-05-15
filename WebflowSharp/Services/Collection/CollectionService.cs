using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.Collection
{
    public class CollectionService : WebflowService
    {
        public CollectionService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Returns List of collection
        /// </summary>
        /// <param name="siteId">	Unique identifier for the site</param>
        public virtual async Task<List<SiteCollection>> GetCollections(string siteId)
        {
            var req = PrepareRequest($"sites/{siteId}/collections");
            return await ExecuteRequestAsync<List<SiteCollection>>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Get Collection with Full Schema
        /// </summary>
        /// <param name="collectionId">Unique identifier for the Collection</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<SiteCollection> GetCollectionById(string collectionId)
        {
            var req = PrepareRequest($"collections/{collectionId}");
            return await ExecuteRequestAsync<SiteCollection>(req, HttpMethod.Get);
        }
        
        /// <summary>
        /// 	Unique identifier for the Collection you are querying
        /// </summary>
        public virtual async Task<ItemQueryResponse> GetCollectionItems(string collectionId, CollectionQueryParameters queryParameters)
        {
            var req = PrepareRequest($"collections/{collectionId}/items");
            if (queryParameters != null) req.QueryParams.AddRange(queryParameters.ToParameters());
            return await ExecuteRequestAsync<ItemQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Get Single Item
        /// </summary>
        /// <param name="collectionId">Unique identifier for the Collection you are querying</param>
        /// <param name="itemId">Unique identifier for the Item you are querying</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> GetCollectionItemById(string collectionId, string itemId)
        {
            var req = PrepareRequest($"collections/{collectionId}/items/{itemId}");
            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Get);
        }

        /// <summary>
        /// An “update item” request" replaces the fields of an existent item with the fields specified in the payload.
        /// </summary>
        /// <param name="collectionId">Unique identifier for the Collection you are querying</param>
        /// <param name="itemId">Unique identifier for the Item you are querying</param>
        /// <param name="collectionItemQueryParameters"></param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> UpdateCollectionItem(string collectionId, string itemId, UpdateCollectionItemQueryParameters collectionItemQueryParameters)
        {
            var req = PrepareRequest($"collections/{collectionId}/items/{itemId}");
            HttpContent content = null;

            if (collectionItemQueryParameters != null)
            {
                var body = collectionItemQueryParameters.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Put, content);
        }
    }
}
