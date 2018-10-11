using Newtonsoft.Json;

namespace StrayG.Boats.Data.Contracts.Responses.Models
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
