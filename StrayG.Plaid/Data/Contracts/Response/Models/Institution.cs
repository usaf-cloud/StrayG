namespace StrayG.Plaid.Data.Contracts.Response.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Institution response.
    /// </summary>
    public class Institution
    {
        [JsonProperty("credentials")]
        public IList<Credentials> Credentials { get; set; }

        [JsonProperty("has_mfa")]
        public bool HasMfa { get; set; }

        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        [JsonProperty("mfa")]
        public IList<string> Mfa { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("products")]
        public IList<string> Products { get; set; }
    }
}