namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Models;

    public class RetrieveFinancialAccountsResponse : PlaidResponse
    {
        [JsonProperty("accounts")]
        public IList<FinancialAccount> Accounts { get; set; }

        [JsonProperty("item")]
        public ItemResponse Item { get; set; }
    }
}
