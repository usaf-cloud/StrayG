using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Walmart.Utilities
{
    public static class WalmartInformation
    {
        #region String Constants
        public static string SearchEndpoint = "search";
        public static string ItemsEndpoint = "items";
        #endregion String Constants

        #region Config File Settings
        /// <summary>
        /// The Walmart endpoint.
        /// </summary>
        /// <returns>The Walmart endpoint.</returns>
        public static string GetWalmartEndpoint()
        {
            return ConfigurationManager.AppSettings["Walmart_Endpoint"];
        }

        /// <summary>
        /// The api key issued by Walmart.
        /// </summary>
        /// <returns>The API Key.</returns>
        public static string GetApiKey()
        {
            return ConfigurationManager.AppSettings["Walmart_ApiKey"];
        }

        /// <summary>
        /// The Link Share Publisher ID issued by Walmart.
        /// </summary>
        /// <returns>The LinkShare Publisher ID.</returns>
        public static string GetLinkSharePublisherId()
        {
            return ConfigurationManager.AppSettings["Walmart_LinkSharePublisherId"];
        }
        #endregion Config File Settings
    }
}
