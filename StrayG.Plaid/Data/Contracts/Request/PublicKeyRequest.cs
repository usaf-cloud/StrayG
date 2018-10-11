namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    internal class PublicKeyRequest
    {
        /// <summary>
        /// The public key provided by Plaid.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        public PublicKeyRequest(string publicKey)
        {
            PublicKey = publicKey;
        }
    }
}
