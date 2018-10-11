namespace StrayG.Plaid
{
    using System;
    using System.Net;
    using Data;

    /// <summary>
    /// The plaid exception.
    /// </summary>
    public class PlaidException : Exception
    {
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
        public PlaidException(string message, ErrorCode errorCode, HttpStatusCode httpStatusCode)
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