using System.IO;

namespace StrayG.Core.Wmf
{
	public interface IBinaryRecord
	{
		void Read(BinaryReader reader);
		void Write(BinaryWriter writer);
		string Dump();
	}
}
