using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.Base;

namespace StrayG.Module.BusinessObjects
{
    [DefaultClassOptions, NavigationItem(false)]
    public class EmailEntity : BaseObject
    {
        public EmailEntity(Session session) : base(session) { }

        #region Private Variables
        string _email;
        OAuthUser _oauthUser;
        bool _useForContact;
        #endregion

        #region Overrides
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //set default values
            UseForContact = true;
        }
        #endregion

        #region Fields
        [RuleRequiredField("Required_Email", DefaultContexts.Save)]
        [RuleUniqueValue("Unique_Email", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRegularExpression("Pattern_Email", DefaultContexts.Save, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email
        {
            get { return _email; }
            set { SetPropertyValue("Email", ref _email, value); }
        }

        public bool UseForContact
        {
            get { return _useForContact; }
            set { SetPropertyValue("UseForContact", ref _useForContact, value); }
        }
        #endregion

        #region Associations
        [Association("OAuthUser-OAuthAuthenticationEmails")]
        [RuleRequiredField("Required_OAuthUser", DefaultContexts.Save)]
        public OAuthUser OAuthUser
        {
            get { return _oauthUser; }
            set { SetPropertyValue("OAuthUser", ref _oauthUser, value); }
        }
        #endregion
    }
}
