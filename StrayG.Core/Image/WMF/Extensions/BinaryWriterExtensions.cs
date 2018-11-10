using System.IO;

namespace StrayG.Core.Wmf
{
	public static class BinaryWriterExtensions
	{
		public static void Write<T>(this BinaryWriter writer, T obj) where T : IBinaryObject
		{
			obj.Write(writer);
		}
	}
}
