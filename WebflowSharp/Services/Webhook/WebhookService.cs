using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.Webhook
{
    class WebhookService : WebflowService
    {
        protected WebhookService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Returns collection of webhooks
        /// <param name="siteId">	Unique identifier for the site</param>
        /// </summary>
        public virtual async Task<List<WebhookModel>> GetWebhooks(string siteId)
        {
            var req = PrepareRequest($"sites/{siteId}/webhooks");
            return await ExecuteRequestAsync<List<WebhookModel>>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a order with provided ID.
        /// </summary>
        /// <param name="webhookId">Unique identifier for the webhook</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<WebhookModel> GetWebhookById(string siteId, string webhookId)
        {
            var req = PrepareRequest($"sites/{siteId}/webhooks/{webhookId}");
            return await ExecuteRequestAsync<WebhookModel>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Create a new webhook
        /// </summary>
        ///  /// <param name="request">update fields value</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> CreateWebhook(string siteId, CreateWebhookRequest request)
        {
            var req = PrepareRequest($"sites/{siteId}/webhooks");
            HttpContent content = null;

            if (request != null)
            {
                var body = request.ToDictionary();
                content = new JsonContent(body);
            }

            return await ExecuteRequestAsync<OrderModel>(req, HttpMethod.Patch, content);
        }

        /// <summary>
        /// Removes a specific webhook
        /// </summary>
        /// <param name="webhookId">Unique identifier for the webhook</param>
        /// <param name="siteId">	Unique identifier for the site</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<Dictionary<string, string>> RemoveWebhhok(string siteId, string webhookId)
        {
            var req = PrepareRequest($"sites/{siteId}/webhooks/{webhookId}");
            return await ExecuteRequestAsync<Dictionary<string, string>>(req, HttpMethod.Delete);
        }
    }
}
