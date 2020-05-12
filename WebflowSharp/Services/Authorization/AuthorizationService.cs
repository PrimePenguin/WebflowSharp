using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;

namespace WebflowSharp.Services.Authorization
{
    public class AuthorizationService : WebflowService
    {
        protected AuthorizationService(string siteId, string secretApiKey) : base(siteId, secretApiKey)
        {
        }

        /// <summary>
        /// Returns collection of orders
        /// </summary>
        public virtual async Task<AuthInfo> GetAuthInfo()
        {
            var req = PrepareAuthInfoRequest();
            return await ExecuteRequestAsync<AuthInfo>(req, HttpMethod.Get);
        }
    }
}
