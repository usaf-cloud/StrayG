using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Plaid.Data.Contracts.Request
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Check here: https://plaid.com/docs/api/#all-institutions for further information.
    /// </summary>
    internal class ListOfInstitutionsRequest : CountOffsetRequest
    {
        [JsonProperty("client_id")]
        public string ClientID { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        public ListOfInstitutionsRequest(string clientID, string secret, int count = 500, int offset = 0) : base(count, offset)
        {
            ClientID = clientID;
            Secret = secret;
        }
    }
}
