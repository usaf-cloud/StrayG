using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Data.Contracts.Response;
using Data.Results;
using Data.Contracts.Request;
using System.Text;
using StrayG.Core.Json;
using StrayG.Core.Http;

namespace StrayG.MDM.MaaS360
{
    /// <summary>
    /// The RESTFUL Http MaaS360 client.
    /// </summary>
    public class HttpMaaS360Client
    {
        #region Member Variables
        /// <summary>
        /// The client id provided by Plaid.
        /// </summary>
        private readonly string clientId;

        /// <summary>
        /// The client secret provided by Plaid.
        /// </summary>
        private readonly string clientSecret;

        /// <summary>
        /// The client public key provided by Plaid.
        /// </summary>
        private readonly string clientPublicKey;

        /// <summary>
        /// The http client.
        /// </summary>
        private readonly IHttpClientWrapper httpClient;
        #endregion Member Variables

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMaaS360Client"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Plaid's service.</param>
        /// <param name="clientId">The client id provided by Plaid.</param>
        /// <param name="clientSecret">The client secret provided by Plaid.</param>
        /// <param name="httpClient">The http client to use for requests.</param>
        internal HttpMaaS360Client(Uri serviceUri, string clientId, string clientSecret, string clientPublicKey, IHttpClientWrapper httpClient)
        {
            Condition.Requires(clientId).IsNotNullOrWhiteSpace();
            Condition.Requires(clientSecret).IsNotNullOrWhiteSpace();
            Condition.Requires(serviceUri).IsNotNull();
            Condition.Requires(httpClient).IsNotNull();

            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.clientPublicKey = clientPublicKey;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = serviceUri;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPlaidClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Plaid's service.</param>
        /// <param name="clientId">The client id provided by Plaid.</param>
        /// <param name="clientSecret">The client secret provided by Plaid.</param>
        public HttpMaaS360Client(Uri serviceUri, string clientId, string clientSecret, string clientPublicKey)
            : this(serviceUri, clientId, clientSecret, clientPublicKey, new HttpClientWrapper())
        { }
        #endregion Constructors

        #region Private Functions
        /// <summary>
        /// Helper to parse exceptions from a plaid service response.
        /// </summary>
        private async Task<MaaS360Exception> ParseException(HttpResponseMessage response, string responseJson = null)
        {
            if (response.IsSuccessStatusCode) return null;

            if (responseJson == null) responseJson = await response.Content.ReadAsStringAsync();

            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseJson);
            return errorResponse?.ToException(response.StatusCode);
        }
        #endregion Private Functions
    }
}
