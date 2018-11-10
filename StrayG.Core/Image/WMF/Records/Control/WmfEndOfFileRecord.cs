using System;

namespace StrayG.Core.Wmf.Records
{
	[WmfRecord(Type = RecordType.META_EOF, Size = 3)]
	public class WmfEndOfFileRecord : WmfBinaryRecord
	{
		public WmfEndOfFileRecord() : base()
		{
		}
	}
}
