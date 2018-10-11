namespace StrayG.Boats.Utilities
{
    using System.Configuration;

    /// <summary>
    /// This static class stores some constants and 
    /// accesses some of the configurations that are set in the config file.
    /// See http://api.boats.com/docs/services/details?s=inventory for more information.
    /// </summary>
    public static class BoatsInformation
    {
        #region String Constants
        public static string InventoryEndpoint = "inventory";
        #endregion String Constants

        #region Config File Settings
        /// <summary>
        /// The consumer key that was assigned by Boats.com.
        /// </summary>
        /// <returns>The consumer key.</returns>
        public static string GetConsumerKey()
        {
            return ConfigurationManager.AppSettings["Boats_ConsumerKey"];
        }

        /// <summary>
        /// The Boats endpoint.
        /// </summary>
        /// <returns>The Boats endpoint.</returns>
        public static string GetBoatsEndpoint()
        {
            return ConfigurationManager.AppSettings["Boats_Endpoint"];
        }
        #endregion Config File Settings
    }
}
