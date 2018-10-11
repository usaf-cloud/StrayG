using Newtonsoft.Json;

namespace StrayG.Boats.Data.Contracts.Requests
{
    /// <summary>
    /// Base class for all BoatsRequest requests.
    /// </summary>
    internal class BoatsRequest
    {
        /// <summary>
        /// Gets or sets the consumer key.
        /// </summary>
        [JsonProperty("key")]
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the Format.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoatsRequest"/> class.
        /// </summary>
        /// <param name="consumerKey">The api key provided by Boats.com.</param>
        /// <param name="lsPublisherId">The LinkShare Publisher Id.</param>
        public BoatsRequest(string consumerKey, string format = "json")
        {
            this.ConsumerKey = consumerKey;
            this.Format = format;
        }
    }
}
