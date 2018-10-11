namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ItemResponse : PlaidResponse
    {
        [JsonProperty("available_products")]
        public IList<string> AvailableProducts { get; set; }

        [JsonProperty("billed_products")]
        public IList<string> BilledProducts { get; set; }

        [JsonProperty("error")]
        public ErrorResponse Error { get; set; }

        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("webhook")]
        public string Webhook { get; set; }
    }
}
