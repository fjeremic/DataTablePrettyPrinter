using System;
using System.Data;
using System.Linq;

namespace DataTablePrettyPrinter
{
    /// <summary>
    /// An extension class providing <see cref="DataTable"/> utility methods for pretty printing to a string.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Gets the border around the entire table.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// The border around the entire table.
        /// </returns>
        public static Border GetBorder(this DataTable table)
        {
            return table.GetExtendedProperty("Border", Border.All);
        }

        /// <summary>
        /// Sets the border around the entire table.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetBorder(this DataTable table, Border value)
        {
            table.SetExtendedProperty("Border", value);
        }

        /// <summary>
        /// Gets whether to show the column header section which shows the column names.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// <c>true</c> if the column header is to be shown; <c>false</c> otherwise.
        /// </returns>
        public static Boolean GetShowColumnHeader(this DataTable table)
        {
            return table.GetExtendedProperty("ShowColumnHeader", true);
        }

        /// <summary>
        /// Sets whether to show the column header section which shows the column names.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetShowColumnHeader(this DataTable table, Boolean value)
        {
            table.SetExtendedProperty("ShowColumnHeader", value);
        }

        /// <summary>
        /// Gets whether to show the <see cref="DataTable.TableName"/>.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// <c>true</c> if the table title is to be shown; <c>false</c> otherwise.
        /// </returns>
        public static Boolean GetShowTableName(this DataTable table)
        {
            return table.GetExtendedProperty("ShowTableName", true);
        }

        /// <summary>
        /// Sets whether to show the <see cref="DataTable.TableName"/>.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetShowTableName(this DataTable table, Boolean value)
        {
            table.SetExtendedProperty("ShowTableName", value);
        }

        /// <summary>
        /// Gets the text alignment of the title determined by the <see cref="DataTable.TableName"/> property.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// Gets the title text alignment.
        /// </returns>
        public static TextAlignment GetTitleTextAlignment(this DataTable table)
        {
            return table.GetExtendedProperty("TitleTextAlignment", TextAlignment.Center);
        }

        /// <summary>
        /// Sets the text alignment of the title determined by the <see cref="DataTable.TableName"/> property.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetTitleTextAlignment(this DataTable table, TextAlignment value)
        {
            table.SetExtendedProperty("TitleTextAlignment", value);
        }

        /// <summary>
        /// Converts the <see cref="DataTable"/> into pretty printed string which can be displayed on the console.
        /// </summary>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The pretty printed table.
        /// </param>
        public static String ToPrettyPrintedString(this DataTable table)
        {
            Int32 x2 = table.Columns.Cast<DataColumn>().Last().GetDataX2();
            Int32 y2 = table.Columns.Cast<DataColumn>().Last().GetDataY2();

            Char[] newLineChars = Environment.NewLine.ToCharArray();
            Char[,] canvas = new Char[y2 + 1, x2 + 1 + newLineChars.Length];

            // Fill the table with spaces and new lines at the end of each row
            for (var y = 0; y < y2 + 1; ++y)
            {
                for (var x = 0; x < x2 + 1; ++x)
                {
                    canvas[y, x] = ' ';
                }

                for (var i = 0; i < newLineChars.Length; ++i)
                {
                    canvas[y, x2 + 1 + i] = newLineChars[i];
                }
            }

            // Draw the table border
            canvas.DrawBorder(0, 0, x2, y2, table.GetBorder());

            // Keep track of the x and y coordinates we are drawing on
            Int32 x1 = 0;
            Int32 y1 = 0;

            if (table.GetShowTableName())
            {
                ++y1;

                var titleAlignment = table.GetTitleTextAlignment();
                canvas.DrawText(2, y1, x2 - 2, y1, table.TableName, titleAlignment);

                ++y1;
            }

            // Cache the column widths for performance
            var cachedColumnWidths = table.Columns.Cast<DataColumn>().Select(c => c.GetWidth()).ToList();

            if (table.GetShowColumnHeader())
            {
                x1 = 0;

                for (var i = 0; i < table.Columns.Count; ++i)
                {
                    // Draw the header border
                    canvas.DrawBorder(x1, y1, x1 + cachedColumnWidths[i] + 1, y1 + 2, table.Columns[i].GetHeaderBorder());

                    if (table.Columns[i].GetShowColumnName())
                    {
                        // Draw the header name
                        canvas.DrawText(x1 + 2, y1 + 1, x1 + 1 + cachedColumnWidths[i] - 2, y1 + 1, table.Columns[i].ColumnName, table.Columns[i].GetColumnNameAlignment());
                    }

                    x1 += cachedColumnWidths[i] + 1;
                }

                y1 += 2;
            }

            x1 = 0;

            for (var i = 0; i < table.Columns.Count; ++i)
            {
                // Draw the data border
                canvas.DrawBorder(x1, y1, x1 + cachedColumnWidths[i] + 1, y1 + table.Rows.Count + 1, table.Columns[i].GetDataBorder());

                x1 += cachedColumnWidths[i] + 1;
            }

            ++y1;

            for (var i = 0; i < table.Rows.Count; ++i)
            {
                x1 = 2;

                for (var j = 0; j < table.Columns.Count; ++j)
                {
                    var dataText = table.Columns[j].GetDataTextFormat().Invoke(table.Columns[j], table.Rows[i]);

                    // Draw the cell text
                    canvas.DrawText(x1, y1, x1 + cachedColumnWidths[j] - 3, y1, dataText, table.Columns[j].GetDataAlignment());

                    x1 += cachedColumnWidths[j] + 1;
                }

                ++y1;
            }

            var buffer = new Char[canvas.GetLength(0) * canvas.GetLength(1)];
            Buffer.BlockCopy(canvas, 0, buffer, 0, buffer.Length * sizeof(Char));

            return new String(buffer);
        }

        /// <summary>
        /// Gets an extended property from the <see cref="DataTable"/> with a default value if it does not exist.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the value to get.
        /// </typeparam>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="property">
        /// The extended property to get.
        /// </param>
        /// 
        /// <param name="defaultValue">
        /// The default value to return if the extended property does not exist.
        /// </param>
        /// 
        /// <returns>
        /// The value of the extended property if it exists; <paramref name="defaultValue"/> otherwise.
        /// </returns>
        internal static T GetExtendedProperty<T>(this DataTable table, String property, T defaultValue = default(T))
        {
            if (table.ExtendedProperties[property] is T)
            {
                return (T)table.ExtendedProperties[property];
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Sets an extended property from the <see cref="DataTable"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the value to get.
        /// </typeparam>
        /// 
        /// <param name="table">
        /// The table to pretty print.
        /// </param>
        /// 
        /// <param name="property">
        /// The extended property to set.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        internal static void SetExtendedProperty<T>(this DataTable table, String property, T value)
        {
            table.ExtendedProperties[property] = value;
        }
    }
}
