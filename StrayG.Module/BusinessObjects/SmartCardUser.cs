using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false)]
    public abstract class SmartCardUser : OAuthUser
    {
        public SmartCardUser(Session session) : base(session) { }

        #region Private Variables
        string _smartCardId;
        #endregion Private Variables

        public string SmartCardId
        {
            get { return _smartCardId; }
            set { SetPropertyValue("SmartCardId", ref _smartCardId, value); }
        }
    }
}
