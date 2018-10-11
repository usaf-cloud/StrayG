namespace StrayG.Plaid.Data.Contracts.Response
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ListOfInstitutionsWithTotalResponse : ListOfInstitutionsResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
