namespace StrayG.Plaid.Data.Contracts.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Models;

    public class ListOfCategoriesResponse : PlaidResponse
    {
        [JsonProperty("categories")]
        public IList<TransactionCategory> Categories { get; set; }
    }
}
