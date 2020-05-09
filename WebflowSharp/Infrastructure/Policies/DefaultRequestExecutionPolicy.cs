using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebflowSharp.Infrastructure;

namespace WebflowSharp
{
    public class DefaultRequestExecutionPolicy : IRequestExecutionPolicy
    {
        public async Task<RequestResult<T>> Run<T>(CloneableRequestMessage request, ExecuteRequestAsync<T> executeRequestAsync, CancellationToken cancellationToken)
        {
            var fullResult = await executeRequestAsync(request);

            return fullResult;
        }
    }
}
