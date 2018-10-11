using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using StrayG.Module.Interfaces;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false)]
    public abstract class OAuthUser : PermissionPolicyUser, IAuthenticationOAuthUser
    {
        public OAuthUser(Session session) : base(session) { }

        #region Private Variables
        bool _enableStandardAuthentication;
        #endregion Private Variables

        public bool EnableStandardAuthentication
        {
            get { return _enableStandardAuthentication; }
            set { SetPropertyValue("EnableStandardAuthentication", ref _enableStandardAuthentication, value); }
        }

        [Association("OAuthUser-OAuthAuthenticationEmails"), Aggregated]
        public XPCollection<EmailEntity> OAuthAuthenticationEmails
        {
            get { return GetCollection<EmailEntity>("OAuthAuthenticationEmails"); }
        }
    }
}
