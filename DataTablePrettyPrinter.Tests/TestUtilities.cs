using System;
using System.Data;
using System.Linq;
using System.Text;

namespace DataTablePrettyPrinter.Tests
{
    internal static class TestUtilities
    {
        internal static String TrimLeadingWhitespace(this String value)
        {
            var sb = new StringBuilder();

            foreach (String line in value.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                String trimmed = line.Trim();

                if (!String.IsNullOrWhiteSpace(trimmed))
                {
                    sb.AppendLine(trimmed);
                }
            }

            return sb.ToString();
        }

        internal static DataTable CreateTypicalTable()
        {
            DataTable table = new DataTable("Prescriptions");

            table.Columns.Add("Dosage", typeof(Int32));
            table.Columns.Add("Drug", typeof(String));
            table.Columns.Add("Patient", typeof(String));
            table.Columns.Add("Date", typeof(String));

            table.Rows.Add(25, "Indocin", "David", "0001-01-01 12:00:12 AM");
            table.Rows.Add(50, "Enebrel", "Sam", "0001-01-01 12:00:12 AM");
            table.Rows.Add(10, "Hydralazine", "Christoff", "0001-01-01 12:00:12 AM");
            table.Rows.Add(21, "Combivent", "Janet", "0001-01-01 12:00:12 AM");
            table.Rows.Add(100, "Dilantin", "Melanie", "0001-01-01 12:00:12 AM");

            return table;
        }

        internal static DataTable CreateTypicalTableWithoutBorders()
        {
            DataTable table = CreateTypicalTable();

            table.SetBorder(Border.None);

            table.Columns.Cast<DataColumn>().AsParallel().ForAll(c => c.SetDataBorder(Border.None));
            table.Columns.Cast<DataColumn>().AsParallel().ForAll(c => c.SetHeaderBorder(Border.None));

            return table;
        }

        internal static DataTable CreateSkinnyTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("A", typeof(String));

            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");
            table.Rows.Add("");

            return table;
        }
    }
}
