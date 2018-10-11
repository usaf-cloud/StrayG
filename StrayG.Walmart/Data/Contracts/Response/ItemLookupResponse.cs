using Newtonsoft.Json;
using StrayG.Walmart.Data.Contracts.Response.Models;
using System.Collections.Generic;

namespace StrayG.Walmart.Data.Contracts.Response
{
    public class ItemLookupResponse : WalmartResponse
    {
        [JsonProperty("items")]
        public IList<ItemFull> Items { get; set; }
    }
}
