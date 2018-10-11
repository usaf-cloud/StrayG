using Newtonsoft.Json;
using StrayG.Boats.Data.Contracts.Responses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Boats.Data.Contracts.Responses
{
    public class ItemLookupResponse : BoatsResponse
    {
        [JsonProperty("numResults")]
        public int NumberOfResults { get; set; }

        [JsonProperty("results")]
        public IList<Item> Items { get; set; }
    }
}
