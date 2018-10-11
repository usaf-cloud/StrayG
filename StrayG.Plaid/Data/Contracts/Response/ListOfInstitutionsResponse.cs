namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using Models;

    public class ListOfInstitutionsResponse : PlaidResponse
    {
        [JsonProperty("institutions")]
        public IList<Institution> Institutions { get; set; }
    }
}
