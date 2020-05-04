using Xunit;

namespace DataTablePrettyPrinter.Tests
{
    public class TestDataTableExtensions
    {
        [Fact]
        public void TestBorder()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(Border.All, table.GetBorder());
            Assert.Equal(@"
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

            table.SetBorder(Border.Left | Border.Top | Border.Right | Border.Bottom);
            Assert.Equal(Border.All, table.GetBorder());

            table.SetBorder(Border.None);
            Assert.Equal(Border.None, table.GetBorder());
            Assert.Equal(@"
                                                                             
                                        Prescriptions                        
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

            table.SetBorder(Border.Left);
            Assert.Equal(Border.Left, table.GetBorder());
            Assert.Equal(@"
                +
                |                       Prescriptions                        
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

            table.SetBorder(Border.Right);
            Assert.Equal(Border.Right, table.GetBorder());
            Assert.Equal(@"
                                                                            +
                                        Prescriptions                       |
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

            table.SetBorder(Border.Top);
            Assert.Equal(Border.Top, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                                        Prescriptions                        
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

            table.SetBorder(Border.Bottom);
            Assert.Equal(Border.Bottom, table.GetBorder());
            Assert.Equal(@"
                                                                             
                                        Prescriptions                        
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

            table.SetBorder(Border.Top | Border.Right);
            Assert.Equal(Border.Top | Border.Right, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                                        Prescriptions                       |
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
        }

        [Fact]
        public void TestBorderOnTypicalTableWithoutBorders()
        {
            var table = TestUtilities.CreateTypicalTableWithoutBorders();

            Assert.Equal(Border.None, table.GetBorder());
            Assert.Equal(@"

                                        Prescriptions
                
                  Dosage      Drug        Patient             Date
                
                  25       Indocin       David       0001-01-01 12:00:12 AM
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM
                  21       Combivent     Janet       0001-01-01 12:00:12 AM
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM
                                                                             "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Left | Border.Top | Border.Right | Border.Bottom);
            Assert.Equal(Border.All, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                |                                                           |
                | Dosage      Drug        Patient             Date          |
                |                                                           |
                | 25       Indocin       David       0001-01-01 12:00:12 AM |
                | 50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                | 10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                | 21       Combivent     Janet       0001-01-01 12:00:12 AM |
                | 100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +-----------------------------------------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Left);
            Assert.Equal(Border.Left, table.GetBorder());
            Assert.Equal(@"
                +                                                               
                |                       Prescriptions                        
                |                                                            
                | Dosage      Drug        Patient             Date           
                |                                                            
                | 25       Indocin       David       0001-01-01 12:00:12 AM  
                | 50       Enebrel       Sam         0001-01-01 12:00:12 AM  
                | 10       Hydralazine   Christoff   0001-01-01 12:00:12 AM  
                | 21       Combivent     Janet       0001-01-01 12:00:12 AM  
                | 100      Dilantin      Melanie     0001-01-01 12:00:12 AM  
                +                                                            "

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Right);
            Assert.Equal(Border.Right, table.GetBorder());
            Assert.Equal(@"
                                                                            +
                                        Prescriptions                       |
                                                                            |
                  Dosage      Drug        Patient             Date          |
                                                                            |
                  25       Indocin       David       0001-01-01 12:00:12 AM |
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                  21       Combivent     Janet       0001-01-01 12:00:12 AM |
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                                                                            +"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Left | Border.Right);
            Assert.Equal(Border.Left | Border.Right, table.GetBorder());
            Assert.Equal(@"
                +                                                           +
                |                       Prescriptions                       |
                |                                                           |
                | Dosage      Drug        Patient             Date          |
                |                                                           |
                | 25       Indocin       David       0001-01-01 12:00:12 AM |
                | 50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                | 10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                | 21       Combivent     Janet       0001-01-01 12:00:12 AM |
                | 100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +                                                           +"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Top | Border.Right | Border.Bottom);
            Assert.Equal(Border.Top | Border.Right | Border.Bottom, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                                        Prescriptions                       |
                                                                            |
                  Dosage      Drug        Patient             Date          |
                                                                            |
                  25       Indocin       David       0001-01-01 12:00:12 AM |
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                  21       Combivent     Janet       0001-01-01 12:00:12 AM |
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +-----------------------------------------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Top | Border.Right);
            Assert.Equal(Border.Top | Border.Right, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                                        Prescriptions                       |
                                                                            |
                  Dosage      Drug        Patient             Date          |
                                                                            |
                  25       Indocin       David       0001-01-01 12:00:12 AM |
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                  21       Combivent     Janet       0001-01-01 12:00:12 AM |
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                                                                            +"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetBorder(Border.Bottom);
            Assert.Equal(Border.Bottom, table.GetBorder());
            Assert.Equal(@"
                                                                             
                                        Prescriptions                        
                                                                             
                  Dosage      Drug        Patient             Date           
                                                                             
                  25       Indocin       David       0001-01-01 12:00:12 AM  
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM  
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM  
                  21       Combivent     Janet       0001-01-01 12:00:12 AM  
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM  
                +-----------------------------------------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetShowTableName(false);
            table.SetShowColumnHeader(false);
            table.SetBorder(Border.Top | Border.Right | Border.Bottom);
            Assert.Equal(Border.Top | Border.Right | Border.Bottom, table.GetBorder());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                  25       Indocin       David       0001-01-01 12:00:12 AM |
                  50       Enebrel       Sam         0001-01-01 12:00:12 AM |
                  10       Hydralazine   Christoff   0001-01-01 12:00:12 AM |
                  21       Combivent     Janet       0001-01-01 12:00:12 AM |
                  100      Dilantin      Melanie     0001-01-01 12:00:12 AM |
                +-----------------------------------------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestShowColumnHeader()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.True(table.GetShowColumnHeader());
            Assert.Equal(@"
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

            table.SetShowColumnHeader(false);
            Assert.False(table.GetShowColumnHeader());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                |                       Prescriptions                       |
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetShowTableName(false);
            Assert.False(table.GetShowTableName());
            Assert.Equal(@"
                +--------+-------------+-----------+------------------------+
                | 25     | Indocin     | David     | 0001-01-01 12:00:12 AM |
                | 50     | Enebrel     | Sam       | 0001-01-01 12:00:12 AM |
                | 10     | Hydralazine | Christoff | 0001-01-01 12:00:12 AM |
                | 21     | Combivent   | Janet     | 0001-01-01 12:00:12 AM |
                | 100    | Dilantin    | Melanie   | 0001-01-01 12:00:12 AM |
                +--------+-------------+-----------+------------------------+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetShowColumnHeader(true);
            Assert.True(table.GetShowColumnHeader());
            Assert.Equal(@"
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
        }

        [Fact]
        public void TestShowTableName()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.True(table.GetShowTableName());
            Assert.Equal(@"
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

            table.SetShowTableName(false);
            Assert.False(table.GetShowTableName());
            Assert.Equal(@"
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

            table.TableName = "A really long table name that will not fit in the title bounding box";
            table.SetShowTableName(true);
            Assert.True(table.GetShowTableName());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                | A really long table name that will not fit in the title.. |
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
        }

        [Fact]
        public void TestShowTableNameOnSkinnyTable()
        {
            var table = TestUtilities.CreateSkinnyTable();

            Assert.True(table.GetShowTableName());
            Assert.Equal(@"
                +---+
                |   |
                +---+
                | A |
                +---+
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                +---+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.SetShowTableName(false);
            Assert.False(table.GetShowTableName());
            Assert.Equal(@"
                +---+
                | A |
                +---+
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                +---+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.TableName = "T";
            table.SetShowTableName(true);
            Assert.True(table.GetShowTableName());
            Assert.Equal(@"
                +---+
                | T |
                +---+
                | A |
                +---+
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                +---+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());

            table.TableName = "Table name that doesn't fit";
            table.SetShowTableName(true);
            Assert.True(table.GetShowTableName());
            Assert.Equal(@"
                +---+
                |   |
                +---+
                | A |
                +---+
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                |   |
                +---+"

                .TrimLeadingWhitespace(), table.ToPrettyPrintedString().TrimLeadingWhitespace());
        }

        [Fact]
        public void TestTitleTextAlignment()
        {
            var table = TestUtilities.CreateTypicalTable();

            Assert.Equal(TextAlignment.Center, table.GetTitleTextAlignment());
            Assert.Equal(@"
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

            table.SetTitleTextAlignment(TextAlignment.Left);
            Assert.Equal(TextAlignment.Left, table.GetTitleTextAlignment());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                | Prescriptions                                             |
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

            table.SetTitleTextAlignment(TextAlignment.Right);
            Assert.Equal(TextAlignment.Right, table.GetTitleTextAlignment());
            Assert.Equal(@"
                +-----------------------------------------------------------+
                |                                             Prescriptions |
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
        }
    }
}
