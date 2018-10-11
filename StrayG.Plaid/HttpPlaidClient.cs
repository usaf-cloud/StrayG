namespace StrayG.Plaid
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CuttingEdge.Conditions;
    using Newtonsoft.Json;
    using StrayG.Plaid.Data.Contracts.Response.Models;
    using Data.Contracts.Response;
    using Utilities;
    using Data.Results;
    using Data.Contracts.Request;
    using System.Text;
    using StrayG.Core.Json;
    using StrayG.Core.Http;

    /// <summary>
    /// The RESTFUL Http Plaid client.
    /// </summary>
    public class HttpPlaidClient : IPlaidClient
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
        /// Initializes a new instance of the <see cref="HttpPlaidClient"/> class.
        /// </summary>
        /// <param name="serviceUri">The base uri to Plaid's service.</param>
        /// <param name="clientId">The client id provided by Plaid.</param>
        /// <param name="clientSecret">The client secret provided by Plaid.</param>
        /// <param name="httpClient">The http client to use for requests.</param>
        internal HttpPlaidClient(Uri serviceUri, string clientId, string clientSecret, string clientPublicKey, IHttpClientWrapper httpClient)
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
        public HttpPlaidClient(Uri serviceUri, string clientId, string clientSecret, string clientPublicKey)
            : this(serviceUri, clientId, clientSecret, clientPublicKey, new HttpClientWrapper())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPlaidClient"/> class with information from
        /// <see cref="PlaidInformation"/> static class.
        /// </summary>
        public HttpPlaidClient() : this(new Uri(PlaidInformation.GetPlaidEnvironmentURL()),
                PlaidInformation.GetClientId(),
                PlaidInformation.GetSecret(),
                PlaidInformation.GetPublicKey())
        { }
        #endregion Constructors

        #region Private Functions
        /// <summary>
        /// Helper to parse exceptions from a plaid service response.
        /// </summary>
        private async Task<PlaidException> ParseException(HttpResponseMessage response, string responseJson = null)
        {
            if (response.IsSuccessStatusCode) return null;

            if (responseJson == null) responseJson = await response.Content.ReadAsStringAsync();

            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseJson);
            return errorResponse?.ToException(response.StatusCode);
        }
        #endregion Private Functions

        #region Getting Pertinent Information
        /// <inheritdoc />
        public Uri GetServiceUri()
        {
            return httpClient.BaseAddress;
        }
        #endregion Getting Pertinent Information

        #region Tokens
        /// <inheritdoc />
        public async Task<PlaidResult<AccessTokenResponse>> ExchangePublicTokenForAccessTokenAsync(string publicToken)
        {
            //conditions
            Condition.Requires(publicToken).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new ExchangePublicTokenForAccessTokenRequest(clientId, clientSecret, publicToken);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.LinkEndpoint_ExchangePublicToken, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<AccessTokenResponse> result = new PlaidResult<AccessTokenResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                AccessTokenResponse exchangeTokenResponse = JsonConvert.DeserializeObject<AccessTokenResponse>(responseJson);
                result.Value = exchangeTokenResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }

        /// <inheritdoc />
        public async Task<PlaidResult<PublicTokenResponse>> CreatePublicTokenAsync(string accessToken)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();

            //create the payload to pass
            PlaidRequest publicTokenRequest = new PlaidRequest(this.clientId, this.clientSecret, accessToken);

            //pass and get response
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(PlaidInformation.LinkEndpoint_CreatePublicToken, publicTokenRequest);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<PublicTokenResponse> result = new PlaidResult<PublicTokenResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                PublicTokenResponse tokenResponse = JsonConvert.DeserializeObject<PublicTokenResponse>(responseJson);

                result.Value = tokenResponse;

                return result;
            }

            result.Exception = await this.ParseException(response, responseJson);
            return result;
        }

        /// <inheritdoc />
        public async Task<PlaidResult<RotateAccessTokenResponse>> RotateAccessTokenAsync(string accessToken)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();

            //create the payload to pass
            PlaidRequest rotateTokenRequest = new PlaidRequest(this.clientId, this.clientSecret, accessToken);

            //pass and get response
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(PlaidInformation.ItemManagement_RotateAccessToken, rotateTokenRequest);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<RotateAccessTokenResponse> result = new PlaidResult<RotateAccessTokenResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                RotateAccessTokenResponse tokenResponse = JsonConvert.DeserializeObject<RotateAccessTokenResponse>(responseJson);

                result.Value = tokenResponse;

                return result;
            }

            result.Exception = await this.ParseException(response, responseJson);
            return result;
        }
        #endregion Tokens

        #region Institutions
        /// <inheritdoc />
        public async Task<PlaidResult<ListOfInstitutionsResponse>> SearchInstitutions(string query, IList<string> products = null)
        {
            //conditions
            Condition.Requires(query).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new InstitutionSearchRequest(clientPublicKey, query, products);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.Institutions_SearchInstitutions, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<ListOfInstitutionsResponse> result = new PlaidResult<ListOfInstitutionsResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ListOfInstitutionsResponse listOfInstitutionsResponse = JsonConvert.DeserializeObject<ListOfInstitutionsResponse>(responseJson);
                result.Value = listOfInstitutionsResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }

        /// <inheritdoc />
        public async Task<PlaidResult<Institution>> GetInstitutionAsync(string id)
        {
            //conditions
            Condition.Requires(id).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new InstitutionRequest(clientPublicKey, id);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.Institutions_GetInstitutionsById, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<Institution> result = new PlaidResult<Institution>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Institution institutionResponse = JsonConvert.DeserializeObject<Institution>(responseJson);
                result.Value = institutionResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }

        /// <inheritdoc />
        public async Task<PlaidResult<ListOfInstitutionsWithTotalResponse>> GetListOfInstitutionsAsync(int count = 500, int offset = 0)
        {
            //conditions
            Condition.Ensures(count >= 0);
            Condition.Ensures(offset >= 0);

            //create the payload to pass
            var payload = new ListOfInstitutionsRequest(clientId, clientSecret, count, offset);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.Institutions_GetInstitutions, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<ListOfInstitutionsWithTotalResponse> result = new PlaidResult<ListOfInstitutionsWithTotalResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ListOfInstitutionsWithTotalResponse listOfInstitutionsResponse = JsonConvert.DeserializeObject<ListOfInstitutionsWithTotalResponse>(responseJson);
                result.Value = listOfInstitutionsResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion Institutions

        #region Accounts
        /// <inheritdoc />
        public async Task<PlaidResult<RetrieveFinancialAccountsResponse>> RetrieveAccountsAsync(string accessToken)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new PlaidRequest(clientId, clientSecret, accessToken);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.ItemManagement_GetAccounts, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<RetrieveFinancialAccountsResponse> result = new PlaidResult<RetrieveFinancialAccountsResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                RetrieveFinancialAccountsResponse retAccsResponse = JsonConvert.DeserializeObject<RetrieveFinancialAccountsResponse>(responseJson);
                result.Value = retAccsResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion Accounts

        #region Transactions
        /// <inheritdoc />
        public async Task<PlaidResult<RetrieveTransactionsResponse>> RetrieveTransactionsAsync(string accessToken, DateTimeOffset startDate, DateTimeOffset endDate, int count = 250, int offset = 0)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();
            Condition.Requires(startDate).IsLessOrEqual(endDate);
            Condition.Requires(count).IsGreaterThan(0);
            Condition.Requires(offset).IsGreaterOrEqual(0);

            //create the payload to pass
            var payload = new RetrieveTransactionsRequest(clientId, clientSecret, accessToken, startDate, endDate, count, offset);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.ProductAccessEndpoint_GetTransactions, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<RetrieveTransactionsResponse> result = new PlaidResult<RetrieveTransactionsResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                RetrieveTransactionsResponse retAccsResponse = JsonConvert.DeserializeObject<RetrieveTransactionsResponse>(responseJson);
                result.Value = retAccsResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion Transactions

        #region Items
        /// <inheritdoc />
        public async Task<PlaidResult<ItemResponse>> GetItemAsync(string accessToken)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new PlaidRequest(clientId, clientSecret, accessToken);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.ItemManagement_GetItems, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<ItemResponse> result = new PlaidResult<ItemResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ItemResponse itemResponse = JsonConvert.DeserializeObject<ItemResponse>(responseJson);
                result.Value = itemResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }

        /// <inheritdoc />
        public async Task<PlaidResult<ItemResponse>> UpdateWebHookAsync(string accessToken, string webhook)
        {
            //conditions
            Condition.Requires(accessToken).IsNotNullOrWhiteSpace();
            Condition.Requires(webhook).IsNotNullOrWhiteSpace();

            //create the payload to pass
            var payload = new UpdateWebHookRequest(clientId, clientSecret, accessToken, webhook);

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync(PlaidInformation.ItemManagement_UpdateWebhook, content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<ItemResponse> result = new PlaidResult<ItemResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ItemResponse itemResponse = JsonConvert.DeserializeObject<ItemResponse>(responseJson);
                result.Value = itemResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion Items

        #region Categories
        /// <inheritdoc />
        public async Task<PlaidResult<ListOfCategoriesResponse>> GetListOfCategoriesAsync()
        {
            //create the payload to pass
            var payload = string.Empty;

            //serialize object
            HttpContent content = ContentExtensions.ToJsonContent(payload);

            //post it and get the response
            HttpResponseMessage response = await this.httpClient.PostAsync("categories/get", content);

            //read the string
            string responseJson = await response.Content.ReadAsStringAsync();

            //create the result
            PlaidResult<ListOfCategoriesResponse> result = new PlaidResult<ListOfCategoriesResponse>(responseJson);

            //is it ok
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ListOfCategoriesResponse listCategoriesResponse = JsonConvert.DeserializeObject<ListOfCategoriesResponse>(responseJson);
                result.Value = listCategoriesResponse;
            }

            //parse the exception
            result.Exception = await this.ParseException(response, responseJson);

            //return
            return result;
        }
        #endregion Categories
    }
}