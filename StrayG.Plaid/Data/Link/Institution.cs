namespace StrayG.Plaid.Data.Link
{
    using Newtonsoft.Json;

    /// <summary>
    /// Refer to https://plaid.com/docs/api/#parameter-reference
    /// </summary>
    public class Institution
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        [JsonProperty("auth")]
        public bool Auth { get; set; }

        [JsonProperty("transactions")]
        public bool Transactions { get; set; }
    }
}
    