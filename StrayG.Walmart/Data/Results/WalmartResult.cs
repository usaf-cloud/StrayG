using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Walmart.Data.Results
{
    /// <summary>
    /// Generic result from Walmart which could possibly be an error.
    /// </summary>
    /// <typeparam name="T">The type of response value.</typeparam>
    public class WalmartResult<T> : WalmartResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WalmartResult{T}"/> class.
        /// </summary>
        public WalmartResult(string rawJSON)
        {
            RawJSON = rawJSON;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WalmartResult{T}"/> class.
        /// </summary>
        /// <param name="value">The return value.</param>
        public WalmartResult(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the result value.
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Generic result from Walmart which could possibly be an error.
    /// </summary>
    public abstract class WalmartResult
    {
        /// <summary>
        /// Gets exception information if a request was not successful.
        /// </summary>
        public WalmartException Exception { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the operation resulted in an error.
        /// </summary>
        public bool IsError => this.Exception != null;

        /// <summary>
        /// Gets or sets the RawJSON.
        /// </summary>
        public string RawJSON { get; set; }
    }
}
