namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;

    public class RotateAccessTokenResponse : PlaidResponse
    {
        [JsonProperty("new_access_token")]
        public string NewAccessToken { get; set; }
    }
}
