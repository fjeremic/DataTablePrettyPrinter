namespace DataTablePrettyPrinter.Tests
{
    using System;
    using Xunit;

    public class TestDataColumnExtensions
    {
        [Fact]
        public void TestDataBorder()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(Border.All, table.Columns[0].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataBorder(Border.Left);
            Assert.Equal(Border.Left, table.Columns[0].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataBorder(Border.Left);
            table.Columns[1].SetDataBorder(Border.Right);
            Assert.Equal(Border.Left, table.Columns[0].GetDataBorder());
            Assert.Equal(Border.Right, table.Columns[1].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25       Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50       Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10       Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21       Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100      Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +----------------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Top | Border.Right);
            table.Columns[0].SetDataBorder(Border.Left | Border.Bottom);
            table.Columns[1].SetDataBorder(Border.Right);
            Assert.Equal(Border.Left | Border.Bottom, table.Columns[0].GetDataBorder());
            Assert.Equal(Border.Right, table.Columns[1].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                                        Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25       Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50       Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10       Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21       Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100      Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+             +-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestDataBorderOnTypicalTableWithoutBorders()
        {
            var table = TestUtilities.CreateTypicalTableWithoutBorders();

            Assert.Equal(Border.None, table.Columns[0].GetDataBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                
                  25       Indocin       David       0001-01-01 12:00:12 AM
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM
                  21       Combivent     Janet       0001-01-01 12:00:12 AM
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM
                                                                             "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataBorder(Border.All);
            Assert.Equal(Border.All, table.Columns[0].GetDataBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                +--------+
                | 25     | Indocin       David       0001-01-01 12:00:12 AM
                | 50     | Enebrel       Sam         0001-01-01 12:00:12 AM
                | 10     | Hydralazine   Christoff   0001-01-01 12:00:12 AM
                | 21     | Combivent     Janet       0001-01-01 12:00:12 AM
                | 100    | Dilantin      Melanie     0001-01-01 12:00:12 AM
                +--------+                                                   "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataBorder(Border.Left);
            table.Columns[1].SetDataBorder(Border.Right | Border.Bottom);
            Assert.Equal(Border.Left, table.Columns[0].GetDataBorder());
            Assert.Equal(Border.Right | Border.Bottom, table.Columns[1].GetDataBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                +                      +
                | 25       Indocin     | David       0001-01-01 12:00:12 AM
                | 50       Enebrel     | Sam         0001-01-01 12:00:12 AM
                | 10       Hydralazine | Christoff   0001-01-01 12:00:12 AM
                | 21       Combivent   | Janet       0001-01-01 12:00:12 AM
                | 100      Dilantin    | Melanie     0001-01-01 12:00:12 AM
                +        +-------------+                                     "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.All);
            table.Columns[0].SetDataBorder(Border.Top);
            table.Columns[1].SetDataBorder(Border.Top);
            table.Columns[2].SetDataBorder(Border.Top);
            table.Columns[3].SetDataBorder(Border.Top);
            Assert.Equal(Border.Top, table.Columns[0].GetDataBorder());
            Assert.Equal(Border.Top, table.Columns[1].GetDataBorder());
            Assert.Equal(Border.Top, table.Columns[2].GetDataBorder());
            Assert.Equal(Border.Top, table.Columns[3].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                |                                                           |
                | Dosage      Drug        Patient             Date          |
                +--------+-------------+-----------+------------------------+
                | 25       Indocin       David       0001-01-01 12:00:12 AM |
                | 50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                | 10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                | 21       Combivent     Janet       0001-01-01 12:00:12 AM |
                | 100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +-----------------------------------------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.All);
            table.Columns[0].SetDataBorder(Border.Top | Border.Bottom);
            table.Columns[1].SetDataBorder(Border.Top);
            table.Columns[2].SetDataBorder(Border.Top);
            table.Columns[3].SetDataBorder(Border.Top | Border.Bottom);
            Assert.Equal(Border.Top | Border.Bottom, table.Columns[0].GetDataBorder());
            Assert.Equal(Border.Top, table.Columns[1].GetDataBorder());
            Assert.Equal(Border.Top, table.Columns[2].GetDataBorder());
            Assert.Equal(Border.Top | Border.Bottom, table.Columns[3].GetDataBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                |                                                           |
                | Dosage      Drug        Patient             Date          |
                +--------+-------------+-----------+------------------------+
                | 25       Indocin       David       0001-01-01 12:00:12 AM |
                | 50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                | 10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                | 21       Combivent     Janet       0001-01-01 12:00:12 AM |
                | 100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +--------+-------------------------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestDataAlignment()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(TextAlignment.Left, table.Columns[0].GetDataAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataAlignment(TextAlignment.Center);
            Assert.Equal(TextAlignment.Center, table.Columns[0].GetDataAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                |   25   | Indocin     | David     | 0001-01-01 12:00:12 AM |
                |   50   | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                |   10   | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                |   21   | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                |  100   | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataAlignment(TextAlignment.Right);
            Assert.Equal(TextAlignment.Right, table.Columns[0].GetDataAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                |     25 | Indocin     | David     | 0001-01-01 12:00:12 AM |
                |     50 | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                |     10 | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                |     21 | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                |    100 | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataAlignment(TextAlignment.Right);
            table.Columns[1].SetDataAlignment(TextAlignment.Center);
            table.Columns[2].SetDataAlignment(TextAlignment.Right);
            table.Columns[3].SetDataAlignment(TextAlignment.Center);
            Assert.Equal(TextAlignment.Right, table.Columns[0].GetDataAlignment());
            Assert.Equal(TextAlignment.Center, table.Columns[1].GetDataAlignment());
            Assert.Equal(TextAlignment.Right, table.Columns[2].GetDataAlignment());
            Assert.Equal(TextAlignment.Center, table.Columns[3].GetDataAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                |     25 |   Indocin   |     David | 0001-01-01 12:00:12 AM |
                |     50 |   Enebrel   |       Sam | 0001-01-01 12:00:12 AM |
                |     10 | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                |     21 |  Combivent  |     Janet | 0001-01-01 12:00:12 AM |
                |    100 |  Dilantin   |   Melanie | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestDataTextFormat()
        {
            var table = TestUtilities.CreateTypicalTable();

            table.Columns[0].SetDataTextFormat((c, r) => "5");
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 5      | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 5      | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 5      | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 5      | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 5      | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataTextFormat((c, r) => "1234567890");
            Assert.Equal(
                @"
                +---------------------------------------------------------------+
                |                         Prescriptions                         |
                +------------+-------------+-----------+------------------------+
                |   Dosage   |    Drug     |  Patient  |          Date          |
                +------------+-------------+-----------+------------------------+
                | 1234567890 | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 1234567890 | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 1234567890 | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 1234567890 | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 1234567890 | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +------------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataTextFormat((c, r) => "1234567890");
            table.Columns[1].SetDataTextFormat((c, r) => r[c].ToString().Length.ToString());
            Assert.Equal(
                @"
                +--------------------------------------------------------+
                |                     Prescriptions                      |
                +------------+------+-----------+------------------------+
                |   Dosage   | Drug |  Patient  |          Date          |
                +------------+------+-----------+------------------------+
                | 1234567890 | 7    | David     | 0001-01-01 12:00:12 AM |
                | 1234567890 | 7    | Sam       | 0001-01-01 12:00:12 AM |
                | 1234567890 | 11   | Christoff | 0001-01-01 12:00:12 AM |
                | 1234567890 | 9    | Janet     | 0001-01-01 12:00:12 AM |
                | 1234567890 | 8    | Melanie   | 0001-01-01 12:00:12 AM |
                +------------+------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetDataTextFormat((c, r) => string.Format("0x{0:X4}", r[c]));
            table.Columns[1].SetDataTextFormat((c, r) => r[c].ToString().Length.ToString());
            table.Columns[2].SetDataTextFormat((c, r) =>
            {
                if (table.Rows.IndexOf(r) == 3)
                {
                    return "My special name";
                }
                else
                {
                    return r[c].ToString();
                }
            });
            Assert.Equal(
                @"
                +----------------------------------------------------------+
                |                      Prescriptions                       |
                +--------+------+-----------------+------------------------+
                | Dosage | Drug |     Patient     |          Date          |
                +--------+------+-----------------+------------------------+
                | 0x0019 | 7    | David           | 0001-01-01 12:00:12 AM |
                | 0x0032 | 7    | Sam             | 0001-01-01 12:00:12 AM |
                | 0x000A | 11   | Christoff       | 0001-01-01 12:00:12 AM |
                | 0x0015 | 9    | My special name | 0001-01-01 12:00:12 AM |
                | 0x0064 | 8    | Melanie         | 0001-01-01 12:00:12 AM |
                +--------+------+-----------------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestDataTextFormatOrdinalNumber()
        {
            var table = TestUtilities.CreateTypicalTable();

            table.Columns.Add("Index", typeof(int)).SetOrdinal(0);
            table.Columns[0].SetDataTextFormat((c, r) => table.Rows.IndexOf(r).ToString());
            Assert.Equal(
                @"
                +-------------------------------------------------------------------+
                |                           Prescriptions                           |
                +-------+--------+-------------+-----------+------------------------+
                | Index | Dosage |    Drug     |  Patient  |          Date          |
                +-------+--------+-------------+-----------+------------------------+
                | 0     | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 1     | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 2     | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 3     | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 4     | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +-------+--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestHeaderBorder()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(Border.All, table.Columns[0].GetHeaderBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetHeaderBorder(Border.Bottom);
            Assert.Equal(Border.Bottom, table.Columns[0].GetHeaderBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                |        +-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetHeaderBorder(Border.Bottom);
            table.Columns[1].SetHeaderBorder(Border.Top);
            table.Columns[2].SetHeaderBorder(Border.Left | Border.Bottom);
            table.Columns[3].SetHeaderBorder(Border.Right);
            Assert.Equal(Border.Bottom, table.Columns[0].GetHeaderBorder());
            Assert.Equal(Border.Top, table.Columns[1].GetHeaderBorder());
            Assert.Equal(Border.Left | Border.Bottom, table.Columns[2].GetHeaderBorder());
            Assert.Equal(Border.Right, table.Columns[3].GetHeaderBorder());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                |        +-------------+                                    +
                | Dosage      Drug     |  Patient             Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestHeaderBorderOnTypicalTableWithoutBorders()
        {
            var table = TestUtilities.CreateTypicalTableWithoutBorders();

            Assert.Equal(Border.None, table.Columns[0].GetHeaderBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                
                  25       Indocin       David       0001-01-01 12:00:12 AM
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM
                  21       Combivent     Janet       0001-01-01 12:00:12 AM
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM
                                                                             "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetHeaderBorder(Border.Bottom);
            Assert.Equal(Border.Bottom, table.Columns[0].GetHeaderBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                +--------+
                  25       Indocin       David       0001-01-01 12:00:12 AM
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM
                  21       Combivent     Janet       0001-01-01 12:00:12 AM
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM
                                                                             "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetHeaderBorder(Border.Bottom | Border.Right);
            table.Columns[1].SetHeaderBorder(Border.Top);
            table.Columns[2].SetHeaderBorder(Border.Left | Border.Bottom);
            table.Columns[3].SetHeaderBorder(Border.Left | Border.Top | Border.Right);
            Assert.Equal(Border.Bottom | Border.Right, table.Columns[0].GetHeaderBorder());
            Assert.Equal(Border.Top, table.Columns[1].GetHeaderBorder());
            Assert.Equal(Border.Left | Border.Bottom, table.Columns[2].GetHeaderBorder());
            Assert.Equal(Border.Left | Border.Top | Border.Right, table.Columns[3].GetHeaderBorder());
            Assert.Equal(
                @"

                                        Prescriptions
                         +-------------+           +------------------------+
                  Dosage |    Drug     |  Patient  |          Date          |
                +--------+             +-----------+                        +
                  25       Indocin       David       0001-01-01 12:00:12 AM
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM
                  21       Combivent     Janet       0001-01-01 12:00:12 AM
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM
                                                                             "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestColumnNameAlignment()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(TextAlignment.Center, table.Columns[1].GetColumnNameAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |    Drug     |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[1].SetColumnNameAlignment(TextAlignment.Left);
            Assert.Equal(TextAlignment.Left, table.Columns[1].GetColumnNameAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage | Drug        |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[1].SetColumnNameAlignment(TextAlignment.Right);
            Assert.Equal(TextAlignment.Right, table.Columns[1].GetColumnNameAlignment());
            Assert.Equal(
                @"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | Dosage |        Drug |  Patient  |          Date          |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestShowColumnName()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.True(table.Columns[0].GetShowColumnName());

            table.Columns[0].SetShowColumnName(false);
            Assert.False(table.Columns[0].GetShowColumnName());
            Assert.Equal(
                @"
                +--------------------------------------------------------+
                |                     Prescriptions                      |
                +-----+-------------+-----------+------------------------+
                |     |    Drug     |  Patient  |          Date          |
                +-----+-------------+-----------+------------------------+
                | 25  | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50  | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10  | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21  | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100 | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +-----+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetShowColumnName(false);
            table.Columns[2].SetShowColumnName(false);
            Assert.False(table.Columns[0].GetShowColumnName());
            Assert.False(table.Columns[2].GetShowColumnName());
            Assert.Equal(
                @"
                +--------------------------------------------------------+
                |                     Prescriptions                      |
                +-----+-------------+-----------+------------------------+
                |     |    Drug     |           |          Date          |
                +-----+-------------+-----------+------------------------+
                | 25  | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50  | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10  | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21  | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100 | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +-----+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestWidth()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(8, table.Columns[0].GetWidth());

            table.Columns[0].SetWidth(15);
            Assert.Equal(15, table.Columns[0].GetWidth());
            Assert.Equal(
                @"
                +------------------------------------------------------------------+
                |                          Prescriptions                           |
                +---------------+-------------+-----------+------------------------+
                |    Dosage     |    Drug     |  Patient  |          Date          |
                +---------------+-------------+-----------+------------------------+
                | 25            | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50            | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10            | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21            | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100           | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +---------------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(2);
            Assert.Equal(2, table.Columns[0].GetWidth());
            Assert.Equal(
                @"
                +-----------------------------------------------------+
                |                    Prescriptions                    |
                +--+-------------+-----------+------------------------+
                |  |    Drug     |  Patient  |          Date          |
                +--+-------------+-----------+------------------------+
                |  | Indocin     | David     | 0001-01-01 12:00:12 AM |
                |  | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                |  | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                |  | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                |  | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(4);
            Assert.Equal(4, table.Columns[0].GetWidth());
            Assert.Equal(
                @"
                +-------------------------------------------------------+
                |                     Prescriptions                     |
                +----+-------------+-----------+------------------------+
                | .. |    Drug     |  Patient  |          Date          |
                +----+-------------+-----------+------------------------+
                | 25 | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50 | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10 | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21 | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | .. | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +----+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(5);
            Assert.Equal(5, table.Columns[0].GetWidth());
            Assert.Equal(
                @"
                +--------------------------------------------------------+
                |                     Prescriptions                      |
                +-----+-------------+-----------+------------------------+
                | D.. |    Drug     |  Patient  |          Date          |
                +-----+-------------+-----------+------------------------+
                | 25  | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50  | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10  | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21  | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100 | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +-----+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(5);
            table.Columns[1].SetWidth(5);
            table.Columns[2].SetWidth(5);
            table.Columns[3].SetWidth(5);
            Assert.Equal(5, table.Columns[0].GetWidth());
            Assert.Equal(5, table.Columns[1].GetWidth());
            Assert.Equal(5, table.Columns[2].GetWidth());
            Assert.Equal(5, table.Columns[3].GetWidth());
            Assert.Equal(
                @"
                +-----------------------+
                |     Prescriptions     |
                +-----+-----+-----+-----+
                | D.. | D.. | P.. | D.. |
                +-----+-----+-----+-----+
                | 25  | I.. | D.. | 0.. |
                | 50  | E.. | Sam | 0.. |
                | 10  | H.. | C.. | 0.. |
                | 21  | C.. | J.. | 0.. |
                | 100 | D.. | M.. | 0.. |
                +-----+-----+-----+-----+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(2);
            table.Columns[1].SetWidth(2);
            table.Columns[2].SetWidth(2);
            table.Columns[3].SetWidth(2);
            Assert.Equal(2, table.Columns[0].GetWidth());
            Assert.Equal(2, table.Columns[1].GetWidth());
            Assert.Equal(2, table.Columns[2].GetWidth());
            Assert.Equal(2, table.Columns[3].GetWidth());
            Assert.Equal(
                @"
                +-----------+
                | Prescri.. |
                +--+--+--+--+
                |  |  |  |  |
                +--+--+--+--+
                |  |  |  |  |
                |  |  |  |  |
                |  |  |  |  |
                |  |  |  |  |
                |  |  |  |  |
                +--+--+--+--+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.Columns[0].SetWidth(0);
            table.Columns[1].SetWidth(0);
            table.Columns[2].SetWidth(0);
            table.Columns[3].SetWidth(0);
            Assert.Equal(1, table.Columns[0].GetWidth());
            Assert.Equal(1, table.Columns[1].GetWidth());
            Assert.Equal(1, table.Columns[2].GetWidth());
            Assert.Equal(1, table.Columns[3].GetWidth());
            Assert.Equal(
                @"
                +-------+
                | Pre.. |
                +-+-+-+-+
                | | | | |
                +-+-+-+-+
                | | | | |
                | | | | |
                | | | | |
                | | | | |
                | | | | |
                +-+-+-+-+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }
    }
}
