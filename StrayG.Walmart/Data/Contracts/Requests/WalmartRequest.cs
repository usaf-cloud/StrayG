using Newtonsoft.Json;

namespace StrayG.Walmart.Data.Contracts.Requests
{
    /// <summary>
    /// Base class for all Walmart requests.
    /// </summary>
    internal class WalmartRequest
    {
        /// <summary>
        /// Gets or sets the api key.
        /// </summary>
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the LinkShare Publisher Id.
        /// </summary>
        [JsonProperty("lsPublisherId")]
        public string LSPublisherId { get; set; }

        /// <summary>
        /// Gets or sets the Format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WalmartRequest"/> class.
        /// </summary>
        /// <param name="apiKey">The api key provided by Walmart.</param>
        /// <param name="lsPublisherId">The LinkShare Publisher Id.</param>
        public WalmartRequest(string apiKey, string lsPublisherId, string format = "json")
        {
            this.ApiKey = apiKey;
            this.LSPublisherId = lsPublisherId;
            this.Format = format;
        }
    }
}
