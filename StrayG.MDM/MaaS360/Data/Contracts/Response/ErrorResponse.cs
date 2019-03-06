using System;
using System.Net;
using StrayG.MDM.MaaS360.Data;

namespace StrayG.MDM.MaaS360.Data.Contracts.Response
{
    /// <summary>
    /// The error response object returned from Plaid.
    /// </summary>
    public class ErrorResponse : MaaS360Response
    {
        /// <summary>
        /// Gets or sets the display message.
        /// </summary>
        [JsonProperty("display_message")]
        public string DisplayMessage { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the error type.
        /// </summary>
        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        /// <summary>
        /// Converts this contract into a <see cref="PlaidException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Plaid.</param>
        /// <returns>The <see cref="PlaidException"/> model.</returns>
        public PlaidException ToException(int httpStatusCode)
        {
            ErrorCode errorCode = Data.ErrorCode.Unknown;
            Enum.TryParse(this.ErrorCode.ToString(), true, out errorCode);

            string message = string.Format("Request Id: {0}; Error Type: {1}; Error Code: {2}; Error Message: {3}; Display Message: {4}",
                RequestId, ErrorType, ErrorCode, ErrorMessage, DisplayMessage);

            return new PlaidException(message, errorCode, httpStatusCode);
        }

        /// <summary>
        /// Converts this contract into a <see cref="PlaidException"/> model.
        /// </summary>
        /// <param name="httpStatusCode">The http status code returned from Plaid.</param>
        /// <returns>The <see cref="PlaidException"/> model.</returns>
        public PlaidException ToException(HttpStatusCode httpStatusCode)
        {
            return this.ToException((int)httpStatusCode);
        }
    }
}
