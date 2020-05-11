using System;
using System.Collections.Generic;
using System.Text;

namespace WebflowSharp.Services.Product
{
    public class ProductService : WebflowService
    {
        protected ProductService(string siteId, string secretApiKey) : base(siteId, secretApiKey)
        {
        }
    }
}
