using Newtonsoft.Json;

namespace StrayG.Boats.Data.Contracts.Requests
{
    internal class ItemLookupRequest : BoatsRequest
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        [JsonProperty("id")]
        public string ItemId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemLookupRequest"/> class.
        /// </summary>
        /// <param name="consumerKey">The api key provided by Walmart.</param>
        /// <param name="itemId">The id of the item.</param>
        public ItemLookupRequest(string consumerKey, string itemId) : base(consumerKey)
        {
            this.ItemId = itemId;
        }
    }
}
