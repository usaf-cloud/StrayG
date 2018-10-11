namespace StrayG.Plaid.Data.Link
{
    using Newtonsoft.Json;

    /// <summary>
    /// Refer to https://plaid.com/docs/api/#parameter-reference
    /// </summary>
    public class Account
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string AccountId { get; set; }
    }
}
