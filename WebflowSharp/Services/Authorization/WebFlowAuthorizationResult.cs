using Newtonsoft.Json;

namespace WebflowSharp.Services.Authorization
{
    public class WebFlowAuthorizationResult
    {
        /// <summary>
        /// 	Always will be “bearer”
        /// </summary>
        [JsonProperty("token_type")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 	Token to use when making API requests on behalf of a user
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
