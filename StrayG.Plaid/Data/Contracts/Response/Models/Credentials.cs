namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using Newtonsoft.Json;

    public class Credentials
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
