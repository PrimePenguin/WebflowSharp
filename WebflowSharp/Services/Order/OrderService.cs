using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.Order
{
    public class OrderService : WebflowService
    {
        protected OrderService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Get a list of all orders created for a given site.
        /// </summary>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <param name="queryParameters">Order query parameters</param>
        public virtual async Task<OrderQueryResponse> GetOrders(string siteId, OrderQueryParameters queryParameters = null)
        {
            var req = PrepareRequest($"sites/{siteId}/orders");
            if (queryParameters != null) req.QueryParams.AddRange(queryParameters.ToParameters());
            return await ExecuteRequestAsync<OrderQueryResponse>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Retrieve a specific order placed for a site.
        /// </summary>
        /// <param name="orderId">Unique identifier for the order</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        ///<returns>OrderModel</returns>
        public virtual async Task<OrderModel> GetOrderById(string siteId, string orderId)
        {
            var req = PrepareRequest($"sites/{siteId}/order/{orderId}/");
            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Updates an order’s status to fulfilled
        /// </summary>
        /// <param name="orderId">	Unique identifier for the order</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>OrderModel</returns>
        public virtual async Task<OrderModel> FulfillOrder(string siteId, string orderId)
        {
            var req = PrepareRequest($"sites/{siteId}/order/{orderId}/fulfill");
            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Post);
        }

        /// <summary>
        /// Updates an order’s status to unfulfilled
        /// </summary>
        /// <param name="orderId">	Unique identifier for the order</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>OrderModel</returns>
        public virtual async Task<OrderModel> UnFulfillOrder(string siteId, string orderId)
        {
            var req = PrepareRequest($"sites/{siteId}/order/{orderId}/unfulfill");
            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Post);
        }

        /// <summary>
        /// This API lets you update the fields, comment, shippingProvider, and/or shippingTracking for a given order. All three fields can be updated simultaneously or independently.
        /// </summary>
        /// <param name="orderId">Requested order ID, specifies the order to update.</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        ///  /// <param name="fields">update fields value</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> UpdateOrder(string siteId, string orderId, UpdateOrderFields fields)
        {
            var req = PrepareRequest($"sites/{siteId}/order/{orderId}/");
            HttpContent content = null;

            if (fields != null)
            {
                var body = fields.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// This API will reverse a Stripe charge and refund an order back to a customer. It will also set the order’s status to refunded..
        /// </summary>
        /// <param name="orderId">Requested order ID</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> RefundOrder(string siteId, string orderId)
        {
            var req = PrepareRequest($"sites/{siteId}/order/{orderId}/refund");
            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Post);
        }
    }
}
