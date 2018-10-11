using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayG.Core.Extensions
{
    public static class DataTableExtensions
    {
        public static IEnumerable<DataTable> Chunkify(this DataTable table, int chunkSize)
        {
            for (int i = 0; i < table.Rows.Count; i += chunkSize)
            {
                DataTable Chunk = table.Clone();

                foreach (DataRow Row in table.Select().Skip(i).Take(chunkSize))
                {
                    Chunk.ImportRow(Row);
                }

                yield return Chunk;
            }
        }
    }
}
