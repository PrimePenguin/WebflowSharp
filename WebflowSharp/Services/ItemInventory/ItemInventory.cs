using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.ItemInventory
{
    public class ItemInventory : WebflowService
    {
        protected ItemInventory(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Get the current inventory levels for a particular SKU item.
        /// </summary>
        /// <param name="collectionId">Unique identifier for the SKUs collection</param>
        /// <param name="itemId">Unique identifier for a SKU item</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<ItemInventoryResponse> GetItemInventory(string collectionId, string itemId)
        {
            var req = PrepareRequest($"collections/{collectionId}/items/{itemId}/inventory");
            return await ExecuteRequestAsync<ItemInventoryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Updates the current inventory levels for a particular SKU item. Updates may be given in one or two methods, absolutely or incrementally. Absolute updates are done by setting quantity directly. Incremental updates are by specifying the inventory delta in updateQuantity which is then added to the quantity stored on the server.
        /// </summary>
        /// <param name="itemId">Unique identifier for a SKU item</param>
        /// <param name="collectionId">Unique identifier for the SKUs collection</param>
        ///  /// <param name="fields">update fields value</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<UpdateItemInventoryResponse> UpdateItemInventory(string collectionId, string itemId, UpdateItemInventoryFields fields)
        {
            var req = PrepareRequest($"collections/{collectionId}/items/{itemId}/inventory");
            HttpContent content = null;

            if (fields != null)
            {
                var body = fields.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<UpdateItemInventoryResponse>(req, HttpMethod.Patch, content);
        }
    }
}
