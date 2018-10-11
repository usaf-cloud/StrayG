using System;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;

namespace StrayG.Module
{
	public sealed partial class StrayGModule : ModuleBase
    {
		public StrayGModule()
        {
			InitializeComponent();

            //register stuff
        }

		/*protected override IEnumerable<Type> GetRegularTypes()
        {
			return new Type[] { typeof(WebHyperLinkStringPropertyEditor) };
		}*/

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
