using System;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using StrayG.Module.Web.PropertyEditors;

namespace StrayG.Module.Web
{
	public sealed partial class StrayGWebModule : ModuleBase
    {
		public StrayGWebModule()
        {
			InitializeComponent();
		}
		protected override IEnumerable<Type> GetRegularTypes()
        {
			return new Type[] { typeof(WebHyperLinkStringPropertyEditor) };
		}
		protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
			return Type.EmptyTypes;
		}
		protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
			return Type.EmptyTypes;
		}
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
			return ModuleUpdater.EmptyModuleUpdaters;
		}
	}
}
