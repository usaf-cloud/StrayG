using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Module.Security
{
    [DomainComponent]
    public class SmartCardLogonParameters : AuthenticationStandardLogonParameters, ICustomObjectSerialize
    {
        private string _smartCardIdNumber;
        [Browsable(false)]
        public string SmartCardIdNumber
        {
            get
            {
                return _smartCardIdNumber;
            }
            set
            {
                _smartCardIdNumber = value;
            }
        }

        private bool _smartCardAuthenticated;
        [Browsable(false)]
        public bool SmartCardAuthenticated
        {
            get
            {
                return _smartCardAuthenticated;
            }
            set
            {
                _smartCardAuthenticated = value;
            }
        }

        private IObjectSpace _objectSpace;
        [Browsable(false)]
        public IObjectSpace ObjectSpace
        {
            get { return _objectSpace; }
            set { _objectSpace = value; }
        }
    }
}
