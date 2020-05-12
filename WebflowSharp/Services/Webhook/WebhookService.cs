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
        protected WebhookService(string siteId, string secretApiKey) : base(siteId, secretApiKey)
        {
        }

        /// <summary>
        /// Returns collection of webhooks
        /// </summary>
        public virtual async Task<List<WebhookModel>> GetWebhooks()
        {
            var req = PrepareRequest("webhooks");
            return await ExecuteRequestAsync<List<WebhookModel>>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Returns a order with provided ID.
        /// </summary>
        /// <param name="webhookId">Unique identifier for the webhook</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<WebhookModel> GetWebhookById(string webhookId)
        {
            var req = PrepareRequest($"webhooks/{webhookId}");
            return await ExecuteRequestAsync<WebhookModel>(req, HttpMethod.Get);
        }

        /// <summary>
        /// Create a new webhook
        /// </summary>
        ///  /// <param name="request">update fields value</param>
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<OrderModel> CreateWebhook(CreateWebhookRequest request)
        {
            var req = PrepareRequest("webhooks");
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
        /// <returns>The <see cref="Order"/>.</returns>
        public virtual async Task<Dictionary<string, string>> RemoveWebhhok(string webhookId)
        {
            var req = PrepareRequest($"webhooks/{webhookId}");
            return await ExecuteRequestAsync<Dictionary<string, string>>(req, HttpMethod.Delete);
        }
    }
}
