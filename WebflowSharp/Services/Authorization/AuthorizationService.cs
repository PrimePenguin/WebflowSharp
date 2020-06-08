using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebflowSharp.Entities;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.Authorization
{
    public class AuthorizationService : WebflowService
    {
        public AuthorizationService(string shopAccessToken) : base(shopAccessToken)
        {
        }

        /// <summary>
        /// Returns collection of orders
        /// </summary>
        public virtual async Task<AuthInfo> GetAuthInfo()
        {
            var req = PrepareRequest("info");
            return await ExecuteRequestAsync<AuthInfo>(req, HttpMethod.Get);
        }

        public static Uri BuildAuthorizationUrl(string webFlowClientKey, string state = null)
        {
            return new Uri($"https://webflow.com/oauth/authorize/?client_id={webFlowClientKey}&state={state}&response_type=code");
        }

        /// <summary>
        /// Authorizes an application installation, generating an access token for the given shop.
        /// </summary>
        /// <param name="code">	Authorization code used to retrieve an access_token for the user. Can only be used once.</param>
        /// <param name="webFlowAppKey">Unique ID for your application.</param>
        /// <param name="webFlowAppSecretKey">	Private value unique to your application.</param>
        /// <returns>The shop access token.</returns>
        public static async Task<WebFlowAuthorizationResult> Authorize(string code, string webFlowAppKey, string webFlowAppSecretKey)
        {
            return (await AuthorizeWithResult(code, webFlowAppKey, webFlowAppSecretKey));
        }

        /// <summary>
        /// Authorizes an application installation, generating an access token for the given shop.
        /// </summary>
        /// <param name="code">Authorization code used to retrieve an access_token for the user. Can only be used once.</param>
        /// <param name="webFlowAppKey">Unique ID for your application.</param>
        /// <param name="webFlowAppSecretKey">	Private value unique to your application.</param>
        /// <returns>The authorization result.</returns>
        public static async Task<WebFlowAuthorizationResult> AuthorizeWithResult(string code, string webFlowAppKey, string webFlowAppSecretKey)
        {
            var ub = new UriBuilder(BuildWebFlowUri("api.webflow.com"))
            {
                Path = "oauth/access_token"
            };

            var content = new JsonContent(new
            {
                code,
                client_secret = webFlowAppSecretKey,
                client_id = webFlowAppKey,
                grant_type = "authorization_code"
            });

            using (var client = new HttpClient())
            using (var msg = new CloneableRequestMessage(ub.Uri, HttpMethod.Post, content))
            {
                var request = client.SendAsync(msg);
                var response = await request;
                var rawDataString = await response.Content.ReadAsStringAsync();

                CheckResponseExceptions(response, rawDataString);
                return JsonConvert.DeserializeObject<WebFlowAuthorizationResult>(rawDataString);
            }
        }
    }
}
