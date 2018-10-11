using StrayG.Module.BusinessObjects;
using DevExpress.Xpo;

namespace StrayG.Module.Interfaces
{
    public interface IAuthenticationOAuthUser
    {
        string UserName { get; set; }
        XPCollection<EmailEntity> OAuthAuthenticationEmails { get; }
        bool EnableStandardAuthentication { get; }
    }
}
