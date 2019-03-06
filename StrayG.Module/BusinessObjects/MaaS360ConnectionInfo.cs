using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false)]
    public class MaaS360ConnectionInfo : MDMConnectionInfo
    {
        public MaaS360ConnectionInfo(Session session) : base(session) { }

        #region Overrides
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //set default values
            SetDefaults();
        }
        #endregion

        #region Private Variables
        string _appAccessKey;
        string _appName;
        string _appID;
        string _appVersionNumber;
        string _accountBillingID;
        string _adminUserName;
        string _adminUserPassword;
        string _maas360PlatformID;
        string _maas360RootURL;   
        #endregion Private Variables

        #region Fields
        /// <summary>
        /// The application specific access key provisioned by Fiberlink support in MaaS360.
        /// </summary>
        public string AppAccessKey
        {
            get { return _appAccessKey; }
            set { SetPropertyValue("AppAccessKey", ref _appAccessKey, value); }
        }

        /// <summary>
        /// The application specific name provisioned by Fiberlink support in MaaS360.
        /// </summary>
        public string AppName
        {
            get { return _appName; }
            set { SetPropertyValue("AppName", ref _appName, value); }
        }

        /// <summary>
        /// The application specific ID provisioned by Fiberlink support in MaaS360.
        /// </summary>
        public string AppID
        {
            get { return _appID; }
            set { SetPropertyValue("AppID", ref _appID, value); }
        }

        /// <summary>
        /// The application specific access version provisioned by Fiberlink support in MaaS360.
        /// </summary>
        public string AppVersionNumber
        {
            get { return _appVersionNumber; }
            set { SetPropertyValue("AppVersionNumber", ref _appVersionNumber, value); }
        }

        /// <summary>
        /// The account billing ID that you can lookup on MaaS360.
        /// </summary>
        public string AccountBillingID
        {
            get { return _accountBillingID; }
            set { SetPropertyValue("AccountBillingID", ref _accountBillingID, value); }
        }

        /// <summary>
        /// The user name of the admin user who has access to the API and has a "Service Administrator" role.
        /// </summary>
        public string AdminUserName
        {
            get { return _adminUserName; }
            set { SetPropertyValue("AdminUserName", ref _adminUserName, value); }
        }

        /// <summary>
        /// The password of the admin user who has access to the API and has a "Service Administrator" role.
        /// </summary>
        public string AdminUserPassword
        {
            get { return _adminUserPassword; }
            set { SetPropertyValue("AdminUserPassword", ref _adminUserPassword, value); }
        }

        /// <summary>
        /// The platform ID of the MaaS360 instance. 
        /// Use 3 for now.
        /// </summary>
        public string MaaS360PlatformID
        {
            get { return _maas360PlatformID; }
            set { SetPropertyValue("MaaS360PlatformID", ref _maas360PlatformID, value); }
        }

        /// <summary>
        /// The root URL of the MaaS360 instance. 
        /// Depends on your MaaS360 instance:
        /// M1: https://services.fiberlink.com/
        /// M2: https://services.m2.maas360.com/
        /// M3: https://services.m3.maas360.com/
        /// </summary>
        public string MaaS360RootURL
        {
            get { return _maas360RootURL; }
            set { SetPropertyValue("MaaS360RootURL", ref _maas360RootURL, value); }
        }
        #endregion Fields

        #region Utility Functions
        public void SetDefaults()
        {
            MaaS360PlatformID = "3";
            MaaS360RootURL = "https://services.m3.maas360.com/";
        }
        #endregion
    }
}
