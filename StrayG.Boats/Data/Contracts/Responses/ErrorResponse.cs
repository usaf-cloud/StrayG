using System;
using System.Net;
using Newtonsoft.Json;

namespace StrayG.Boats.Data.Contracts.Responses
{
    /// <summary>
    /// The error response object returned from Boats.com.
    /// </summary>
    public class ErrorResponse : BoatsResponse
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
        /// Converts this contract into a <see cref="BoatsException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Boats.com.</param>
        /// <returns>The <see cref="BoatsException"/> model.</returns>
        public BoatsException ToException(int httpStatusCode)
        {
            ErrorCode errorCode = ErrorCode.Unknown;
            Enum.TryParse(this.Code.ToString(), true, out errorCode);

            string message = string.Format("Error Code: {0}; Error Message: {1}",
                Code, Message);

            return new BoatsException(message, errorCode, httpStatusCode);
        }

        /// <summary>
        /// Converts this contract into a <see cref="BoatsException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Boats.com.</param>
        /// <returns>The <see cref="BoatsException"/> model.</returns>
        public BoatsException ToException(HttpStatusCode httpStatusCode)
        {
            return this.ToException((int)httpStatusCode);
        }
    }
}
