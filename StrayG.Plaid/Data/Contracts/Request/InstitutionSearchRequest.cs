namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Check here: https://plaid.com/docs/api/#institutions-by-id for further information.
    /// </summary>
    internal class InstitutionSearchRequest : PublicKeyRequest
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("products")]
        public IList<string> Products { get; set; }

        public InstitutionSearchRequest(string publicKey, string query, IList<string> products) : base(publicKey)
        {
            Query = query;
            Products = products;
        }
    }
}
