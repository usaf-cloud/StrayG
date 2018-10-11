namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TransactionCategory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string CategoryType { get; set; }

        [JsonProperty("hierarchy")]
        public IList<string> Hierarchy { get; set; }
    }
}
