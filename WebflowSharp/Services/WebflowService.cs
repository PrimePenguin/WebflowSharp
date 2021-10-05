using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;
using WebflowSharp.Infrastructure.Policies;

namespace WebflowSharp.Services
{
    public class WebflowService
    {
        private static IRequestExecutionPolicy _GlobalExecutionPolicy = new DefaultRequestExecutionPolicy();

        private IRequestExecutionPolicy _ExecutionPolicy;

        private static JsonSerializer _Serializer = Serializer.JsonSerializer;

        private static HttpClient _Client { get; } = new HttpClient();

        protected Uri _ShopUri { get; set; }

        protected string _accessToken { get; set; }

        protected string _siteId { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="WebflowService" />.
        /// </summary>
        /// <param name="shopAccessToken">access token</param>
        protected WebflowService(string shopAccessToken)
        {
            _accessToken = shopAccessToken;

            // If there's a global execution policy it should be set as this instance's policy.
            // User can override it with instance-specific execution policy.
            _ExecutionPolicy = _GlobalExecutionPolicy ?? new DefaultRequestExecutionPolicy();
        }

        public static Uri BuildWebFlowUri(string webFlowUrl)
        {
            if (Uri.IsWellFormedUriString(webFlowUrl, UriKind.Absolute) == false)
            {
                webFlowUrl = "https://" + webFlowUrl;
            }

            var builder = new UriBuilder(webFlowUrl)
            {
                Scheme = "https:",
                Port = 443, //SSL port
                Path = ""
            };

            return builder.Uri;
        }

        /// <summary>
        /// Sets the execution policy for this instance only. This policy will always be used over the global execution policy.
        /// The instance will revert back to the global execution policy if you pass null to this method.
        /// </summary>
        public void SetExecutionPolicy(IRequestExecutionPolicy executionPolicy)
        {
            // If the user passes null, revert to the global execution policy.
            _ExecutionPolicy = executionPolicy ?? _GlobalExecutionPolicy ?? new DefaultRequestExecutionPolicy();
        }

        /// <summary>
        /// Sets the global execution policy for all *new* instances. Current instances are unaffected, but you can call .SetExecutionPolicy on them.
        /// </summary>
        public static void SetGlobalExecutionPolicy(IRequestExecutionPolicy globalExecutionPolicy)
        {
            _GlobalExecutionPolicy = globalExecutionPolicy;
        }

        protected RequestUri PrepareRequest(string path)
        {
            return new RequestUri(new Uri($"https://api.webflow.com/{path}"));
        }

        /// <summary>
        /// Prepares a request to the path and appends the shop's access token header if applicable.
        /// </summary>
        protected CloneableRequestMessage PrepareRequestMessage(RequestUri uri, HttpMethod method, HttpContent content = null)
        {
            var msg = new CloneableRequestMessage(uri.ToUri(), method, content);

            if (!string.IsNullOrEmpty(_accessToken))
            {
                msg.Headers.Add("Authorization", $"Bearer {_accessToken}");
            }

            //msg.Headers.Add("Accept", "application/json");
            msg.Headers.Add("accept-version", "1.0.0");
            if (method == HttpMethod.Post)
            {
                msg.Headers.Add("Idempotency-Key", Guid.NewGuid().ToString());
            }
            return msg;
        }

        /// <summary>
        /// Executes a request and returns the given type. Throws an exception when the response is invalid.
        /// Use this method when the expected response is a single line or simple object that doesn't warrant its own class.
        /// </summary>
        protected async Task<T> ExecuteRequestAsync<T>(RequestUri uri, HttpMethod method, HttpContent content = null, string rootElement = null) where T : new()
        {
            using (var baseRequestMessage = PrepareRequestMessage(uri, method, content))
            {
                var policyResult = await _ExecutionPolicy.Run(baseRequestMessage, async requestMessage =>
                {
                    var request = _Client.SendAsync(requestMessage);
              
                    using (var response = await request)
                    {
                        var rawResult = await response.Content.ReadAsStringAsync();

                        //Check for and throw exception when necessary.
                        CheckResponseExceptions(response, rawResult);

                        // This method may fail when the method was Delete, which is intendend.
                        // Delete methods should not be parsing the response JSON and should instead
                        // be using the non-generic ExecuteRequestAsync.
                        try
                        {
                            var result = JsonConvert.DeserializeObject<T>(rawResult);
                            return new RequestResult<T>(response, result, rawResult);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                });

                return policyResult;
            }
        }

        /// <summary>
        /// Checks a response for exceptions or invalid status codes. Throws an exception when necessary.
        /// </summary>
        /// <param name="response">The response.</param>
        public static void CheckResponseExceptions(HttpResponseMessage response, string rawResponse)
        {
            int statusCode = (int)response.StatusCode;

            // No error if response was between 200 and 300.
            if (statusCode >= 200 && statusCode < 300)
            {
                return;
            }

            var code = response.StatusCode;

            // If the error was caused by reaching the API rate limit, throw a rate limit exception.
            if ((int)code == 429 /* Too many requests */)
            {
                string listMessage = "Exceeded 2 calls per second for api client. Reduce request rates to resume uninterrupted service.";
                var error = JsonConvert.DeserializeObject<WebflowRateLimitException>(rawResponse);
                error.HttpStatusCode = code;
                error.Message = listMessage;
                throw error;
            }

            var contentType = response.Content.Headers.GetValues("Content-Type").FirstOrDefault();
            var defaultMessage = $"Response did not indicate success. Status: {(int)code} {response.ReasonPhrase}.";

            if (contentType.StartsWithIgnoreCase("application/json") || contentType.StartsWithIgnoreCase("text/json"))
            {
                var error = JsonConvert.DeserializeObject<WebflowException>(rawResponse);
                error.HttpStatusCode = code;
                throw error;
            }
            {
                throw new WebflowException(defaultMessage) { HttpStatusCode = code };
            }
        }
    }
}
