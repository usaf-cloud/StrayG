namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Models;

    public class RetrieveTransactionsResponse : PlaidResponse
    {
        [JsonProperty("accounts")]
        public IList<FinancialAccount> Accounts { get; set; }

        [JsonProperty("total_transactions")]
        public int TotalTransactions { get; set; }

        [JsonProperty("item")]
        public ItemResponse Item { get; set; }

        [JsonProperty("transactions")]
        public IList<Transaction> Transactions { get; set; }
    }
}
