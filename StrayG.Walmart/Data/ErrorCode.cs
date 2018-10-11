using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Walmart.Data
{
    /// <summary>
    /// Error codes returned from Walmart.
    /// <see cref="https://developer.walmartlabs.com/docs/read/API_Error_Response_Codes"/>
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Default unknown error.
        /// </summary>
        Unknown = 0,


        /// <summary>
        /// Invalid request error.
        /// </summary>
        InvalidRequest = 4001,

        /// <summary>
        /// Invalid item id.
        /// </summary>
        InvalidItemId = 4002,

        /// <summary>
        /// Invalid category id.
        /// </summary>
        InvalidCategoryId = 4003,

        /// <summary>
        /// Invalid start parameter.
        /// </summary>
        InvalidStartParam = 4005,

        /// <summary>
        /// Invalid response format.
        /// </summary>
        InvalidResponseFormat = 4007,

        /// <summary>
        /// Missing item id.
        /// </summary>
        MissingItemId = 4008,

        /// <summary>
        /// Missing search query.
        /// </summary>
        MissingSearchQuery = 4009,

        /// <summary>
        /// Start index out of bounds.
        /// </summary>
        StartIndexOutOfBounds = 4010,

        /// <summary>
        /// Internal server error.
        /// </summary>
        InternalServerError = 5000,
    }
}
