using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false), NonPersistent, DefaultProperty("Name")]
    public abstract class AbstractNameType : AbstractAuditType
    {
        public AbstractNameType(Session session) : base(session)
        { }

        #region Private Variables
        string _name;
        #endregion Private Variables

        #region Fields
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public virtual string Name
        {
            get { return _name; }
            set { SetPropertyValue("Name", ref _name, value); }
        }
        #endregion Fields
    }
}
