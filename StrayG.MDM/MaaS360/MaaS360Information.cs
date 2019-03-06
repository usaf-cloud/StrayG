using System.Configuration;

namespace StrayG.MDM.MaaS360
{
    public static class MaaS360Information
    {
        #region String Constants
        public static string RootURL_M1 = "https://services.fiberlink.com/";
        public static string RootURL_M2 = "https://services.m2.maas360.com/";
        public static string RootURL_M3 = "https://services.m3.maas360.com/";
        #endregion String Constants

        #region Config File Settings
        /// <summary>
        /// The API Access key that was given.
        /// </summary>
        /// <returns>The API access key name.</returns>
        public static string GetAPIAccessKey()
        {
            return ConfigurationManager.AppSettings["APIAccessKey"];
        }

        /// <summary>
        /// The app name, assigned by IBM support.
        /// </summary>
        /// <returns>The app name.</returns>
        public static string GetAppName()
        {
            return ConfigurationManager.AppSettings["AppName"];
        }

        /// <summary>
        /// The platform based on the information from IBM support.
        /// </summary>
        /// <returns>The platform.</returns>
        public static string GetPlatform()
        {
            return ConfigurationManager.AppSettings["Platform"];
        }

        /// <summary>
        /// The app id assigned by IBM support
        /// </summary>
        /// <returns>The app id.</returns>
        public static string GetAppID()
        {
            return ConfigurationManager.AppSettings["AppID"];
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
        #endregion Config File Settings
    }
}