using System;
using System.Net;
using Newtonsoft.Json;

namespace WebflowSharp.Infrastructure
{
    public class WebflowException : Exception
    {
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// The type and subtype fields are general purpose descriptors of the kind of error that occurred. The possible values of each are documented per endpoint.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The type and subtype fields are general purpose descriptors of the kind of error that occurred. The possible values of each are documented per endpoint.
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// The message field is intended for you, the developer, and shouldn't be displayed to an end-user or client. The message field will typically contain detailed debug information.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The details field is intended for machine-readable usage in generating user-friendly error messages for you and your users. Note that this field will be null unless otherwise specified.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The contextId field is intended for communicating a server error with Squarespace Customer Care. Please do not hesitate to report this context id along with any occurrences of 5xx-class errors.
        /// </summary>
        public string ContextId { get; set; }

        public WebflowException() { }

        public WebflowException(string message) : base(message) { }

        public WebflowException(HttpStatusCode httpStatusCode, string type, string subType, string message, string details) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Type = type;
            SubType = subType;
            Message = message;
            Details = details;
        }
    }
}