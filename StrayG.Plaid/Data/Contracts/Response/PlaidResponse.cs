namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;

    public abstract class PlaidResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
