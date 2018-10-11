using System.Collections.Generic;
using Newtonsoft.Json;

namespace StrayG.Walmart.Data.Contracts.Requests
{
    internal class ItemLookupRequest : WalmartRequest
    {
        /// <summary>
        /// Gets or sets the item ids as a string comma separated list.
        /// </summary>
        [JsonProperty("ids")]
        public string ItemIds { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemLookupRequest"/> class.
        /// </summary>
        /// <param name="apiKey">The api key provided by Walmart.</param>
        /// <param name="lsPublisherId">The LinkShare Publisher Id.</param>
        public ItemLookupRequest(string apiKey, string lsPublisherId, string itemIds) : base(apiKey, lsPublisherId)
        {
            this.ItemIds = itemIds;
        }
    }
}
