using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using StrayG.Module.Win.Controllers;
using StrayG.Module.Win.PropertyEditors;

namespace StrayG.Module.Win
{
	public sealed partial class StrayGWinModule : ModuleBase
    {
		public StrayGWinModule()
        {
			InitializeComponent();
		}
		protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
			return new Type[] { typeof(GridListEditorOpenHyperLinkViewController) };
		}
		protected override IEnumerable<Type> GetRegularTypes()
        {
			return new Type[] { typeof(WinHyperLinkStringPropertyEditor) };
		}
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
			return ModuleUpdater.EmptyModuleUpdaters;
		}
		protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
			return Type.EmptyTypes;
		}
	}
}
