using System;
using System.Data;
using System.Linq;

namespace DataTablePrettyPrinter
{
    /// <summary>
    /// An extension class providing <see cref="DataRow"/> utility methods for pretty printing to a string.
    /// </summary>
    internal static class DataRowExtensions
    {
        /// <summary>
        /// Gets the width (in characters) of this row as it would appear on the pretty printed table by aggregating
        /// the widths of each induvidual column.
        /// </summary>
        /// 
        /// <param name="row">
        /// The input row.
        /// </param>
        /// 
        /// <returns>
        /// The width (in characters) of this row.
        /// </returns>
        internal static Int32 GetWidth(this DataRow row)
        {
            return row.Table.Columns.Cast<DataColumn>().Aggregate(0, (a, c) => a + c.GetWidth() + 1) - 1;
        }

        /// <summary>
        /// Gets the height (in characters) of this row as it would appear on the pretty printed table by aggregating
        /// the heights of each induvidual column.
        /// </summary>
        /// 
        /// <param name="row">
        /// The input row.
        /// </param>
        /// 
        /// <returns>
        /// The height (in characters) of this row.
        /// </returns>
        internal static Int32 GetHeight(this DataRow row)
        {
            return 1;
        }
    }
}
