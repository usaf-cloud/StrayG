namespace StrayG.Amazon.ECS
{
    using System.Configuration;

    /// <summary>
    /// This static class stores some constants and 
    /// accesses some of the configurations that are set in the config file.
    /// </summary>
    public static class AmazonInformation
    {
        #region Config File Settings
        /// <summary>
        /// The Amazon ECS Endpoint.
        /// </summary>
        /// <returns>The Associate Tag.</returns>
        public static string GetECSSOAPEndpoint()
        {
            return ConfigurationManager.AppSettings["Amazon_ECS_SOAPEndpoint"];
        }

        /// <summary>
        /// The Associate Tag assigned by Amazon.
        /// </summary>
        /// <returns>The Associate Tag.</returns>
        public static string GetAssociateTag()
        {
            return ConfigurationManager.AppSettings["Amazon_ECS_AssociateTag"];
        }

        /// <summary>
        /// The Access Key ID assigned by Amazon.
        /// </summary>
        /// <returns>The Access Key ID.</returns>
        public static string GetAccessKeyID()
        {
            return ConfigurationManager.AppSettings["Amazon_ECS_AccessKeyID"];
        }

        /// <summary>
        /// The Secret Access Key assigned by Amazon.
        /// </summary>
        /// <returns>The Secret Access Key.</returns>
        public static string GetSecretAccessKey()
        {
            return ConfigurationManager.AppSettings["Amazon_ECS_SecretAccessKey"];
        }
        #endregion Config File Settings
    }
}
