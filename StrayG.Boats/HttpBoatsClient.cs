namespace StrayG.Boats
{
    using CuttingEdge.Conditions;
    using Data.Contracts.Requests;
    using Data.Results;
    using Newtonsoft.Json;
    using StrayG.Boats.Data.Contracts.Responses;
    using StrayG.Core.Http;
    using StrayG.Core.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Utilities;


    /// <summary>
    /// The RESTFUL Http Boats client.
    /// </summary>
    public class HttpBoatsClient : IBoatsClient
    {
        #region Member Variables
        /// <summary>
        /// The consumer key provided by Boats.com.
        /// </summary>
        private readonly string consumerKey;

        /// <summary>
        /// The http client.
        /// </summary>
        private readonly IHttpClientWrapper httpClient;
        #endregion Member Variables

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpBoatsClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Boats service.</param>
        /// <param name="consumerKey">The consumer key provided by Boats.com.</param>
        /// <param name="httpClient">The http client to use for requests.</param>
        internal HttpBoatsClient(Uri serviceUri, string consumerKey, IHttpClientWrapper httpClient)
        {
            Condition.Requires(consumerKey).IsNotNullOrWhiteSpace();
            Condition.Requires(serviceUri).IsNotNull();
            Condition.Requires(httpClient).IsNotNull();

            this.consumerKey = consumerKey;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = serviceUri;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPlaidClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Boats service.</param>
        /// <param name="consumerKey">The consumer key provided by Boats.com.</param>
        public HttpBoatsClient(Uri serviceUri, string consumerKey)
            : this(serviceUri, consumerKey, new HttpClientWrapper())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpBoatsClient"/> class with information from
        /// <see cref="BoatsInformation"/> static class.
        /// </summary>
        public HttpBoatsClient() : this(new Uri(BoatsInformation.GetBoatsEndpoint()),
                BoatsInformation.GetConsumerKey())
        { }
        #endregion Constructors

        #region Private Functions
        /// <summary>
        /// Helper to parse exceptions from a plaid service response.
        /// </summary>
        private async Task<BoatsException> ParseException(HttpResponseMessage response, string responseJson = null)
        {
            if (response.IsSuccessStatusCode) return null;

            if (responseJson == null) responseJson = await response.Content.ReadAsStringAsync();

            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseJson);
            return errorResponse?.ToException(response.StatusCode);
        }
        #endregion Private Functions

        #region IBoatsClient
        /// <inheritdoc />
        public Uri GetServiceUri()
        {
            return httpClient.BaseAddress;
        }

        /// <inheritdoc />
        public async Task<BoatsResult<ItemLookupResponse>> ItemLookupAsync(string itemID)
        {
            //conditions
            Condition.Ensures(itemID).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new ItemLookupRequest(this.consumerKey, itemID);

            //serialize object
            var keyValueContent = payload.ToKeyValue();

            //encode as url content
            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);

            //create the URI
            string uri = BoatsInformation.InventoryEndpoint + "?" + await formUrlEncodedContent.ReadAsStringAsync();

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.GetAsync(uri);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            BoatsResult<ItemLookupResponse> result = new BoatsResult<ItemLookupResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ItemLookupResponse itemLookupResponse = JsonConvert.DeserializeObject<ItemLookupResponse>(responseJson);
                result.Value = itemLookupResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion
    }
}
