using System;
using System.Net;
using StrayG.MDM.MaaS360.Data;

namespace StrayG.MDM.MaaS360
{
    /// <summary>
    /// The plaid exception.
    /// </summary>
    public class MaaS360Exception : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaaS360Exception"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="httpStatusCode">
        /// The http status code.
        /// </param>
        public MaaS360Exception(string message, ErrorCode errorCode, HttpStatusCode httpStatusCode)
            : this(message, errorCode, (int)httpStatusCode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaidException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="httpStatusCode">
        /// The http status code.
        /// </param>
        public PlaidException(string message, ErrorCode errorCode, int httpStatusCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
            this.HttpStatusCode = httpStatusCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public ErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets or sets the http status code.
        /// </summary>
        public int HttpStatusCode { get; private set; }
    }
}
