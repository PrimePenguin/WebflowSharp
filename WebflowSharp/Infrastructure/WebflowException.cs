using System;
using System.Net;
using Newtonsoft.Json;

namespace WebflowSharp.Infrastructure
{
    public class WebflowException : Exception
    {
       [JsonProperty("code")]
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// 	Path of request resulting in error
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// 	Name of error
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The message field is intended for you, the developer, and shouldn't be displayed to an end-user or client. The message field will typically contain detailed debug information.
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 	Full error string
        /// </summary>
        [JsonProperty("err")]
        public string Error { get; set; }

        /// <summary>
        /// The contextId field is intended for communicating a server error with Webflow Customer Care. Please do not hesitate to report this context id along with any occurrences of 5xx-class errors.
        /// </summary>
        public string ContextId { get; set; }

        public WebflowException() { }

        public WebflowException(string message) : base(message) { }

        public WebflowException(HttpStatusCode httpStatusCode, string path, string name, string message, string error) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Path = path;
            Name = name;
            Message = message;
            Error = error;
        }
    }
}