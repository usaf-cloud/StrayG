using System.IO;

namespace StrayG.Core.Wmf
{
	public interface IBinaryObject
	{
		int GetSize();
		void Read(BinaryReader reader);
		void Write(BinaryWriter writer);
		string Dump();
	}
}
