
using System.Net;

namespace WebflowSharp.Infrastructure
{
    /// <summary>
    /// An exception thrown when an API call has reached SquareSpaceSharp's rate limit.
    /// </summary>
    public class WebflowRateLimitException : WebflowException
    {
        public WebflowRateLimitException()
        { }

        public WebflowRateLimitException(string message) : base(message) { }

        public WebflowRateLimitException(HttpStatusCode httpStatusCode, string path, string name, string message, string error) : base(httpStatusCode, path, name, message, error) { }
    }
}