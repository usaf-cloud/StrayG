namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Check here: https://plaid.com/docs/api/#institutions-by-id for further information.
    /// </summary>
    internal class InstitutionRequest : PublicKeyRequest
    {
        [JsonProperty("institution_id")]
        public string InstitutionId { get; set; }

        public InstitutionRequest(string publicKey, string institutionId) : base(publicKey)
        {
            InstitutionId = institutionId;
        }
    }
}
