using System.Net.Http;
using System.Threading.Tasks;
using WebflowSharp.Entities;
using WebflowSharp.Extensions;
using WebflowSharp.Infrastructure;

namespace WebflowSharp.Services.Order
{
    public class OrderService : WebflowService
    {
        protected OrderService(string siteId, string secretApiKey) : base(siteId, secretApiKey)
        {
        }
    }
}
