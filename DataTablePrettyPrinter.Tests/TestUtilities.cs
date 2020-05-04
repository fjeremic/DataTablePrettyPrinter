namespace DataTablePrettyPrinter.Tests
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Text;

    internal static class TestUtilities
    {
        internal static string TrimLeadingWhitespace(this string value)
        {
            var sb = new StringBuilder();

            foreach (string line in value.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                string trimmed = line.Trim();

                if (!string.IsNullOrWhiteSpace(trimmed))
                {
                    sb.AppendLine(trimmed);
                }
            }

            return sb.ToString();
        }

        internal static DataTable CreateTypicalTable()
        {
            DataTable table = new DataTable("Prescriptions");

            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(string));

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

            table.Columns.Add("A", typeof(string));

            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);
            table.Rows.Add(string.Empty);

            return table;
        }
    }
}
