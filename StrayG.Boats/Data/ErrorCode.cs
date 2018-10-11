namespace StrayG.Boats.Data
{
    using System;

    /// <summary>
    /// Error codes returned from Boats.com.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Default unknown error.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Bad request. The error message will provide some insight as to what part of the request is malformed.
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Authentication error. The error message will explain why the request could not be authenticated.
        /// </summary>
        AuthenticationError = 401,

        /// <summary>
        /// Not implemented. The API does not support the functionality required to process the request.
        /// </summary>
        NotImplemented = 501,

        /// <summary>
        /// Service unavailable. The error message will explain why the service is not available for use.
        /// </summary>
        ServiceUnavailable = 503,
    }
}
