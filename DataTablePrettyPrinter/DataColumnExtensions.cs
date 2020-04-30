using System;
using System.Data;
using System.Linq;

namespace DataTablePrettyPrinter
{
    /// <summary>
    /// An extension class providing <see cref="DataColumn"/> utility methods for pretty printing to a string.
    /// </summary>
    public static class DataColumnExtensions
    {
        /// <summary>
        /// Gets the border around the data area of the column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// The border around the data area of the column.
        /// </returns>
        public static Border GetDataBorder(this DataColumn column)
        {
            return column.GetExtendedProperty("DataBorder", Border.All);
        }

        /// <summary>
        /// Sets the border around the data area of the column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetDataBorder(this DataColumn column, Border value)
        {
            column.SetExtendedProperty("DataBorder", value);
        }

        /// <summary>
        /// Gets the text alignment of the data in this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// Gets the data alignment.
        /// </returns>
        public static TextAlignment GetDataAlignment(this DataColumn column)
        {
            return column.GetExtendedProperty("DataAlignment", TextAlignment.Left);
        }

        /// <summary>
        /// Sets the text alignment of the data in this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetDataAlignment(this DataColumn column, TextAlignment value)
        {
            column.SetExtendedProperty("DataAlignment", value);
        }

        /// <summary>
        /// Gets the formatting method which given a column and row formats the data of the cell into a string. This
        /// API can be used for arbitrary formatting of induvidual data cells.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// The method which formats the data cell.
        /// </returns>
        public static Func<DataColumn, DataRow, String> GetDataTextFormat(this DataColumn column)
        {
            return column.GetExtendedProperty<Func<DataColumn, DataRow, String>>("DataTextFormat", (c, r) => String.Format("{0}", r[c]));
        }

        /// <summary>
        /// Sets the formatting method which given a column and row formats the data of the cell into a string. This
        /// API can be used for arbitrary formatting of induvidual data cells.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The method used to format the data cell which will be called during pretty printing of the table.
        /// </param>
        public static void SetDataTextFormat(this DataColumn column, Func<DataColumn, DataRow, String> value)
        {
            column.SetExtendedProperty("DataTextFormat", value);
        }

        /// <summary>
        /// Gets the border around the column header area which displays the column names.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// The border around the column header area.
        /// </returns>
        public static Border GetHeaderBorder(this DataColumn column)
        {
            return column.GetExtendedProperty("HeaderBorder", Border.All);
        }

        /// <summary>
        /// Sets the border around the column header area which displays the column names.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetHeaderBorder(this DataColumn column, Border value)
        {
            column.SetExtendedProperty("HeaderBorder", value);
        }

        /// <summary>
        /// Gets the <see cref="DataColumn.ColumnName"/> text alignment.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// Gets the column name text alignment.
        /// </returns>
        public static TextAlignment GetColumnNameAlignment(this DataColumn column)
        {
            return column.GetExtendedProperty("ColumnNameAlignment", TextAlignment.Center);
        }

        /// <summary>
        /// Sets the <see cref="DataColumn.ColumnName"/> text alignment.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetColumnNameAlignment(this DataColumn column, TextAlignment value)
        {
            column.SetExtendedProperty("ColumnNameAlignment", value);
        }

        /// <summary>
        /// Gets whether to show the <see cref="DataTable.TableName"/>.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <returns>
        /// <c>true</c> if the column name is to be shown; <c>false</c> otherwise.
        /// </returns>
        public static Boolean GetShowColumnName(this DataColumn column)
        {
            return column.GetExtendedProperty("ShowColumnName", true);
        }

        /// <summary>
        /// Sets whether to show the <see cref="DataTable.TableName"/>.
        /// </summary>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        public static void SetShowColumnName(this DataColumn column, Boolean value)
        {
            column.SetExtendedProperty("ShowColumnName", value);
        }

        /// <summary>
        /// Gets the width (in characters) of this column as it would appear on the pretty printed table.
        /// </summary>
        /// 
        /// <param name="row">
        /// The input column.
        /// </param>
        /// 
        /// <returns>
        /// The width (in characters) of this column which is retrieved either by user defined value or the aggregate
        /// maximum width of any row in the table.
        /// </returns>
        public static Int32 GetWidth(this DataColumn column)
        {
            if (column.ExtendedProperties.ContainsKey("Width"))
            {
                return (Int32)column.ExtendedProperties["Width"];
            }
            else
            {
                var columnNameLength = 1;

                if (column.GetShowColumnName())
                {
                    columnNameLength = column.ColumnName.Length;
                }

                // Linq.Max cannot handle empty sequences
                if (column.Table.Rows.Count == 0)
                {
                    return columnNameLength + 2;
                }
                else
                {
                    return Math.Max(columnNameLength, column.Table.Rows.Cast<DataRow>().Max(r => column.GetDataTextFormat().Invoke(column, r).Length)) + 2;
                }
            }
        }

        /// <summary>
        /// Sets the width (in characters) of this column as it would appear on the pretty printed table.
        /// </summary>
        /// 
        /// <param name="row">
        /// The input column.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set which will be clamped to be at least 1.
        /// </param>
        public static void SetWidth(this DataColumn column, Int32 value)
        {
            value = Math.Max(1, value);

            column.SetExtendedProperty("Width", value);
        }

        /// <summary>
        /// Gets the beginning X coordinate of the data area of this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The input column.
        /// </param>
        /// 
        /// <returns>
        /// The X coordinate of the beginning of the data area.
        /// </returns>
        internal static Int32 GetDataX1(this DataColumn column)
        {
            var columnIndex = column.Table.Columns.IndexOf(column);

            return column.Table.Columns.Cast<DataColumn>().Take(columnIndex).Aggregate(0, (a, c) => a + c.GetWidth() + 1);
        }


        /// <summary>
        /// Gets the end X coordinate of the data area of this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The input column.
        /// </param>
        /// 
        /// <returns>
        /// The X coordinate of the end of the data area.
        /// </returns>
        internal static Int32 GetDataX2(this DataColumn column)
        {
            return column.GetDataX1() + 1 + column.GetWidth();
        }

        /// <summary>
        /// Gets the beginning Y coordinate of the data area of this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The input column.
        /// </param>
        /// 
        /// <returns>
        /// The Y coordinate of the beginning of the data area.
        /// </returns>
        internal static Int32 GetDataY1(this DataColumn column)
        {
            // Account for the top border
            var y1 = 1;

            // Account for the title and a rule following the title
            if (column.Table.GetShowTableName())
            {
                y1 += 2;
            }

            // Account for the header and a rule following the header
            if (column.Table.GetShowColumnHeader())
            {
                y1 += 2;
            }

            return y1;
        }

        /// <summary>
        /// Gets the end Y coordinate of the data area of this column.
        /// </summary>
        /// 
        /// <param name="column">
        /// The input column.
        /// </param>
        /// 
        /// <returns>
        /// The Y coordinate of the end of the data area.
        /// </returns>
        internal static Int32 GetDataY2(this DataColumn column)
        {
            return column.GetDataY1() + column.Table.Rows.Cast<DataRow>().Aggregate(0, (a, r) => a + r.GetHeight());
        }

        /// <summary>
        /// Gets an extended property from the <see cref="DataColumn"/> with a default value if it does not exist.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the value to get.
        /// </typeparam>
        /// 
        /// <param name="column">
        /// The column to pretty print.
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
        internal static T GetExtendedProperty<T>(this DataColumn column, String property, T defaultValue = default(T))
        {
            if (column.ExtendedProperties[property] is T)
            {
                return (T)column.ExtendedProperties[property];
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Sets an extended property from the <see cref="DataColumn"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the value to get.
        /// </typeparam>
        /// 
        /// <param name="column">
        /// The column to pretty print.
        /// </param>
        /// 
        /// <param name="property">
        /// The extended property to set.
        /// </param>
        /// 
        /// <param name="value">
        /// The value to set.
        /// </param>
        internal static void SetExtendedProperty<T>(this DataColumn column, String property, T value)
        {
            column.ExtendedProperties[property] = value;
        }
    }
}
