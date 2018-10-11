using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using StrayG.Walmart.Data;

namespace StrayG.Walmart.Data.Contracts.Response
{
    /// <summary>
    /// The error response object returned from Plaid.
    /// </summary>
    public class ErrorResponse : WalmartResponse
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Converts this contract into a <see cref="WalmartException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Walmart.</param>
        /// <returns>The <see cref="WalmartException"/> model.</returns>
        public WalmartException ToException(int httpStatusCode)
        {
            ErrorCode errorCode = ErrorCode.Unknown;
            Enum.TryParse(this.Code.ToString(), true, out errorCode);

            string message = string.Format("Error Code: {0}; Error Message: {1}",
                Code, Message);

            return new WalmartException(message, errorCode, httpStatusCode);
        }

        /// <summary>
        /// Converts this contract into a <see cref="WalmartException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Plaid.</param>
        /// <returns>The <see cref="WalmartException"/> model.</returns>
        public WalmartException ToException(HttpStatusCode httpStatusCode)
        {
            return this.ToException((int)httpStatusCode);
        }
    }
}
