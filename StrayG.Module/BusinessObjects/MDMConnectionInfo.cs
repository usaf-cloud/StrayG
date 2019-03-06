using DevExpress.Persistent.Base;
using DevExpress.Xpo;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false)]
    public abstract class MDMConnectionInfo : AbstractNameType
    {
        public MDMConnectionInfo(Session session) : base(session) { }
    }
}
