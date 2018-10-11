namespace StrayG.Plaid.Data.Contracts.Response
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Response contract for ExchangeToken api.
    /// See https://plaid.com/docs/api/#exchange-token-flow
    /// </summary>
    public class AccessTokenResponse : PlaidResponse
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}