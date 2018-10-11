namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Request object to exchange banking tokens.
    /// </summary>
    internal class ExchangePublicTokenForAccessTokenRequest : PlaidRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExchangePublicTokenForAccessTokenRequest"/> class.
        /// </summary>
        public ExchangePublicTokenForAccessTokenRequest(string clientId, string secret, string publicToken): base(clientId, secret)
        {
            this.PublicToken = publicToken;
        }

        /// <summary>
        /// The public token from Plaid Link.
        /// </summary>
        [JsonProperty("public_token")]
        public string PublicToken { get; set; }
    }
}