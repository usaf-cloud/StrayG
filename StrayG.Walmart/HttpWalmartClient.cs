using CuttingEdge.Conditions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StrayG.Core.Http;
using StrayG.Core.Json;
using StrayG.Walmart.Data.Contracts.Requests;
using StrayG.Walmart.Data.Contracts.Response;
using StrayG.Walmart.Data.Results;
using StrayG.Walmart.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Walmart
{
    /// <summary>
    /// The RESTFUL Http Plaid client.
    /// </summary>
    public class HttpWalmartClient : IWalmartClient
    {
        #region Member Variables
        /// <summary>
        /// The api key provided by Walmart.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// The linkshare publisher id provided by Walmart.
        /// </summary>
        private readonly string lsPublisherId;

        /// <summary>
        /// The http client.
        /// </summary>
        private readonly IHttpClientWrapper httpClient;
        #endregion Member Variables

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpWalmartClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Walmart's service.</param>
        /// <param name="apiKey">The client id provided by Walmart.</param>
        /// <param name="lsPublisherId">The LinkShare Publisher Id provided by Walmart.</param>
        /// <param name="httpClient">The http client to use for requests.</param>
        internal HttpWalmartClient(Uri serviceUri, string apiKey, string lsPublisherId, IHttpClientWrapper httpClient)
        {
            Condition.Requires(apiKey).IsNotNullOrWhiteSpace();
            Condition.Requires(serviceUri).IsNotNull();
            Condition.Requires(httpClient).IsNotNull();

            this.apiKey = apiKey;
            this.lsPublisherId = lsPublisherId;
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = serviceUri;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpWalmartClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Plaid's service.</param>
        /// <param name="apiKey">The client id provided by Plaid.</param>
        public HttpWalmartClient(Uri serviceUri, string apiKey, string lsPublisherId)
            : this(serviceUri, apiKey, lsPublisherId, new HttpClientWrapper())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpWalmartClient"/> class with information from
        /// <see cref="WalmartInformation"/> static class.
        /// </summary>
        public HttpWalmartClient() : this(new Uri(WalmartInformation.GetWalmartEndpoint()),
                WalmartInformation.GetApiKey(), WalmartInformation.GetLinkSharePublisherId())
        { }
        #endregion Constructors

        #region IWalmartClient
        /// <inheritdoc />
        public Uri GetServiceUri()
        {
            return httpClient.BaseAddress;
        }

        /// <inheritdoc />
        public async Task<WalmartResult<ItemLookupResponse>> ItemLookupAsync(string itemIDs, string[] upcs)
        {
            //conditions
            Condition.Requires(itemIDs).IsNotNull();
            Condition.Requires(itemIDs.Count()).IsGreaterThan(0);

            //create the payload to pass
            var payload = new ItemLookupRequest(this.apiKey, this.lsPublisherId, itemIDs);

            //serialize object
            var keyValueContent = payload.ToKeyValue();

            //encode as url content
            var formUrlEncodedContent = new FormUrlEncodedContent(keyValueContent);

            //create the URI
            string uri = WalmartInformation.ItemsEndpoint + "?" + await formUrlEncodedContent.ReadAsStringAsync();

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.GetAsync(uri);//.PostAsync(WalmartInformation.ItemsEndpoint, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            WalmartResult<ItemLookupResponse> result = new WalmartResult<ItemLookupResponse>(responseJson);

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
        #endregion IWalmartClient

        #region Private Functions
        /// <summary>
        /// Helper to parse exceptions from a walmart service response.
        /// </summary>
        private async Task<WalmartException> ParseException(HttpResponseMessage response, string responseJson = null)
        {
            if (response.IsSuccessStatusCode) return null;

            if (responseJson == null) responseJson = await response.Content.ReadAsStringAsync();

            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseJson);
            return errorResponse?.ToException(response.StatusCode);
        }
        #endregion Private Functions
    }
}
