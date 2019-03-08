using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StrayG.MDM.MaaS360.Data.Contracts.Request
{
    [Serializable()]
    [XmlRoot("maaS360AdminAuth")]
    public class MaaS360AdminAuth
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaidRequest"/> class.
        /// </summary>
        /// <param name="billingID">Input your billing ID.</param>
        /// <param name="platformID">Platform ID.</param>
        /// <param name="appID">Replace with whatever your appID name is.</param>
        /// <param name="appVersion">Replace with the application version you were provided.</param>
        /// <param name="appAccessKey">Replace with the application key provided.</param>
        /// <param name="userName">Replace with your API username you created.</param>
        /// <param name="password">Replace with your API username’s password in plain text.</param>
        public MaaS360AdminAuth(string billingID, string platformID, string appID, 
            string appVersion, string appAccessKey, string userName, string password)
        {
            this.BillingID = billingID;
            this.PlatformID = platformID;
            this.AppID = appID;
            this.AppVersion = appVersion;
            this.AppAccessKey = appAccessKey;
            this.UserName = userName;
            this.Password = password;
        }

        [XmlElement("billingID")]
        public string BillingID { get; private set; }

        [XmlElement("platformID")]
        public string PlatformID { get; private set; }

        [XmlElement("appID")]
        public string AppID { get; private set; }

        [XmlElement("appVersion")]
        public string AppVersion { get; private set; }

        [XmlElement("appAccessKey")]
        public string AppAccessKey { get; private set; }

        [XmlElement("userName")]
        public string UserName { get; private set; }

        [XmlElement("password")]
        public string Password { get; private set; }
    }
}