namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    internal class UpdateWebHookRequest : PlaidRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWebHookRequest"/> class.
        /// </summary>
        /// <param name="clientId">The client id provided on signup.</param>
        /// <param name="secret">The client secret provided on signup.</param>
        /// <param name="accessToken">The access token associated with the request.</param>
        public UpdateWebHookRequest(string clientId, string secret, string accessToken, string webhook) : base(clientId, secret, accessToken)
        {
            this.WebHook = webhook;
        }

        /// <summary>
        /// Gets or sets the webhook.
        /// </summary>
        [JsonProperty("webhook")]
        public string WebHook { get; set; }
    }
}
