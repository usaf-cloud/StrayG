namespace StrayG.Plaid.Utilities
{
    using System.Configuration;

    /// <summary>
    /// This static class stores some constants and 
    /// accesses some of the configurations that are set in the config file.
    /// See https://plaid.com/docs/api/#overview for more information.
    /// </summary>
    public static class PlaidInformation
    {
        #region String Constants
        public static string ProductAccessEndpoint_GetAuth = "auth/get";
        public static string ProductAccessEndpoint_GetTransactions = "transactions/get";
        public static string ProductAccessEndpoint_GetIncome = "income/get";
        public static string ProductAccessEndpoint_GetIdentity = "identity/get";
        public static string ProductAccessEndpoint_GetAccountBalance = "accounts/balance/get";

        public static string LinkEndpoint_ExchangePublicToken = "item/public_token/exchange";
        public static string LinkEndpoint_CreatePublicToken = "item/public_token/create";

        public static string ItemManagement_GetAccounts = "accounts/get";
        public static string ItemManagement_GetItems = "item/get";
        public static string ItemManagement_UpdateWebhook = "item/webhook/update";
        public static string ItemManagement_RotateAccessToken = "item/access_token/invalidate";
        public static string ItemManagement_UpdateVersionAccessToken = "item/access_token/update_version";
        public static string ItemManagement_DeleteItem = "item/delete";

        public static string Institutions_GetInstitutions = "institutions/get";
        public static string Institutions_GetInstitutionsById = "institutions/get_by_id";
        public static string Institutions_SearchInstitutions = "institutions/search";

        public static string Categories_GetCategories = "categories/get";
        #endregion String Constants

        #region Config File Settings
        /// <summary>
        /// The client name that we choose to use.
        /// </summary>
        /// <returns>The client name.</returns>
        public static string GetClientName()
        {
            return ConfigurationManager.AppSettings["PlaidStrayGClientName"];
        }

        /// <summary>
        /// The client id, assigned by Plaid.
        /// This is stored in the config file or you can access it here:
        /// https://dashboard.plaid.com/overview
        /// </summary>
        /// <returns>The client id.</returns>
        public static string GetClientId()
        {
            return ConfigurationManager.AppSettings["PlaidStrayGClientId"];
        }

        /// <summary>
        /// The public key, assigned by Plaid.
        /// This is stored in the config file or you can access it here:
        /// https://dashboard.plaid.com/overview
        /// </summary>
        /// <returns>The client key.</returns>
        public static string GetPublicKey()
        {
            return ConfigurationManager.AppSettings["PlaidStrayGPublicKey"];
        }

        /// <summary>
        /// The client secret, assigned by Plaid.
        /// This is stored in the config file or you can access it here:
        /// https://dashboard.plaid.com/overview
        /// </summary>
        /// <returns></returns>
        public static string GetSecret()
        {
            return ConfigurationManager.AppSettings["PlaidStrayGSecret"];
        }

        /// <summary>
        /// This is the url of the environment we are using.
        /// This is stored in the config file.
        /// You can view the different urls here: https://dashboard.plaid.com/overview
        /// </summary>
        /// <returns></returns>
        public static string GetPlaidEnvironmentURL()
        {
            return ConfigurationManager.AppSettings["PlaidEnvironmentURL"];
        }

        /// <summary>
        /// This is just the first part after the https://xxxx.plaid.com
        /// Example: https://sandbox.plaid.com and returns "sandbox"
        /// </summary>
        /// <returns></returns>
        public static string GetPlaidEnvironment()
        {
            string url = GetPlaidEnvironmentURL();

            char[] delimiterChars = { '/', '.' };
            string[] parts = url.Split(delimiterChars);

            return parts[2];
        }
        #endregion Config File Settings
    }
}
