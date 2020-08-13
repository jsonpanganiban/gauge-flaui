using System.Linq;
using Gauge.CSharp.Lib;

namespace DTAF.Core.Desktop.Helpers
{
    public static class TableHelper
    {
        public static string FindValue(this Table table, string query)
        {
            return table.GetTableRows().FirstOrDefault(r => r.GetCell("Field") == query)?.GetCell("Value");
        }
    }
}