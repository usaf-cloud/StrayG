using System;

namespace StrayG.Core.Wmf
{
	public enum MetafileVersion
	{
		/// <summary>
		/// DIBs are not supported.
		/// </summary>
		METAVERSION100 = 0x0100,
		/// <summary>
		/// DIBs are supported.
		/// </summary>
		METAVERSION300 = 0x0300
	}
}
