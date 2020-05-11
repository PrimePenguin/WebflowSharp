using System.Net.Http;

namespace WebflowSharp.Infrastructure
{
    public class RequestResult<T>
    {
        public HttpResponseMessage Response { get; }

        public T Result { get; }

        public string RawResult { get; }

        public RequestResult(HttpResponseMessage response, T result, string rawResult)
        {
            Response = response;
            Result = result;
            RawResult = rawResult;
        }
    }
}
