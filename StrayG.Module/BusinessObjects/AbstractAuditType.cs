using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false), CreatableItem(false), NonPersistent]
    public abstract class AbstractAuditType : BaseObject
    {
        public AbstractAuditType(Session session) : base(session)
        { }

        #region NonPersistent
        [NonPersistent]
        private XPCollection<AuditDataItemPersistent> _auditTrail;
        [NonPersistent]
        public XPCollection<AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (_auditTrail == null)
                    _auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                return _auditTrail;
            }
        }
        #endregion NonPersistent
    }
}
