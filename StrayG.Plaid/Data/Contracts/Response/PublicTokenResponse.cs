namespace StrayG.Plaid.Data.Contracts.Response
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Response contract for ExchangeToken api.
    /// See https://plaid.com/docs/api/#exchange-token-flow
    /// </summary>
    public class PublicTokenResponse : PlaidResponse
    {
        /// <summary>
        /// Gets or sets the public token.
        /// </summary>
        [JsonProperty("public_token")]
        public string PublicToken { get; set; }
    }
}