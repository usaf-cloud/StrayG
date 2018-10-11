using System;
using Newtonsoft.Json;

namespace StrayG.Walmart.Data.Contracts.Response.Models
{
    public class Error
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
    }
}
