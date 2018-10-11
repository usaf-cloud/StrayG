namespace StrayG.Plaid
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data.Results;
    using StrayG.Plaid.Data.Contracts.Response;
    using StrayG.Plaid.Data.Contracts.Response.Models;

    /// <summary>
    /// The PlaidClient interface.
    /// </summary>
    public interface IPlaidClient
    {
        #region Getting Pertinent Information
        /// <summary>
        /// Gets the Uri that the PlaidClient is working with.
        /// </summary>
        /// <returns>Service uri.</returns>
        Uri GetServiceUri();
        #endregion Getting Pertinent Information

        #region Tokens
        /// <summary>
        /// Exchanges a public token for an access token.
        /// </summary>
        /// <param name="publicToken">The public token.</param>
        /// <returns><see cref="AccessTokenResponse"/> info.</returns>
        Task<PlaidResult<AccessTokenResponse>> ExchangePublicTokenForAccessTokenAsync(string publicToken);

        /// <summary>
        /// A public_token is one-time use and expires after 30 minutes. You use a public_token to initialize Link in update mode for a particular Item.
        /// If you need your user to take action to restore or resolve an error associated with an Item, generate a public token with the POST /item/public_token/create endpoint and then initialize Link with that public_token.
        /// You can generate a public_token for an Item even if you did not use Link to create the Item originally.
        /// </summary>
        /// <param name="accessToken">The access token for which you want to create a public token.</param>
        /// <returns><see cref="PublicTokenResponse"/></returns>
        Task<PlaidResult<PublicTokenResponse>> CreatePublicTokenAsync(string accessToken);

        /// <summary>
        /// Refreshes an access token.
        /// </summary>
        /// <param name="accessToken">The access token that you want to refresh.</param>
        /// <returns><see cref="RotateAccessTokenResponse"/></returns>
        Task<PlaidResult<RotateAccessTokenResponse>> RotateAccessTokenAsync(string accessToken);
        #endregion Tokens

        #region Institutions
        /// <summary>
        /// Gets specific institution details.
        /// </summary>
        /// <param name="id">The Plaid id of the institution.</param>
        /// <returns><see cref="Institution"/> info.</returns>
        Task<PlaidResult<Institution>> GetInstitutionAsync(string id);

        /// <summary>
        /// Search for institution matching query.
        /// </summary>
        /// <param name="query">The search query. Institutions with names matching the query are returned..</param>
        /// <param name="products">Filter the Institutions based on whether they support all products listed in products. Provide null to get institutions regardless of supported products.</param>
        /// <returns><see cref="ListOfInstitutionsResponse"/> info.</returns>
        Task<PlaidResult<ListOfInstitutionsResponse>> SearchInstitutions(string query, IList<string> products = null);

        /// <summary>
        /// Gets a list of known financial institutions supported by Plaid. Refer to: https://plaid.com/docs/api/#all-institutions
        /// </summary>
        /// <param name="count">The total number of Institutions to return. The minimum is 0 and the maximum is 500..</param>
        /// <param name="offset">The number of Institutions to skip before returning results. The minimum is 1. There is no maximum.</param>
        /// <returns>List of supported <see cref="Institution"/>s.</returns>
        Task<PlaidResult<ListOfInstitutionsWithTotalResponse>> GetListOfInstitutionsAsync(int count = 500, int offset = 0);
        #endregion Institutions

        #region Accounts
        /// <summary>
        /// Gets account balances for the given access token.
        /// </summary>
        /// <param name="accessToken">The access token to get accounts for.</param>
        /// <returns>Async <see cref="Task"/>.</returns>
        Task<PlaidResult<RetrieveFinancialAccountsResponse>> RetrieveAccountsAsync(string accessToken);
        #endregion Accounts

        #region Transactions
        /// <summary>
        /// Gets transactions for the given access token.
        /// </summary>
        /// <param name="accessToken">The access token to get transactions for.</param>
        /// <returns>Async <see cref="Task"/>.</returns>
        Task<PlaidResult<RetrieveTransactionsResponse>> RetrieveTransactionsAsync(string accessToken, DateTimeOffset startDate, DateTimeOffset endDate, int count = 250, int offset = 0);
        #endregion Transactions

        #region Items
        /// <summary>
        /// Gets specific item details.
        /// </summary>
        /// <param name="accessToken">The access token for the item.</param>
        /// <returns><see cref="ItemResponse"/> info.</returns>
        Task<PlaidResult<ItemResponse>> GetItemAsync(string accessToken);

        /// <summary>
        /// Updates the webhook for an item.
        /// </summary>
        /// <param name="accessToken">The access token for the item.</param>
        /// <param name="webhook">The webhook url to use.</param>
        /// <returns><see cref="ItemResponse"/> info.</returns>
        Task<PlaidResult<ItemResponse>> UpdateWebHookAsync(string accessToken, string webhook);
        #endregion Items

        #region Categories
        /// <summary>
        /// Gets a list of detailed category information.
        /// </summary>
        /// <returns>List of all categories in plaid.</returns>
        Task<PlaidResult<ListOfCategoriesResponse>> GetListOfCategoriesAsync();
        #endregion Categories
    }
}