# DataTablePrettyPrinter
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](https://github.com/fjeremic/DataTablePrettyPrinter/blob/master/LICENSE)
[![Build Status](https://dev.azure.com/fjeremic/DataTablePrettyPrinter/_apis/build/status/fjeremic.DataTablePrettyPrinter?branchName=master)](https://dev.azure.com/fjeremic/DataTablePrettyPrinter/_build/latest?definitionId=6&branchName=master)

An extension library of System.Data.DataTable which provides extension methods for fully customizable pretty-printing of DataTables to an ASCII formatted string which can be displayed on the console or any text buffer.

## Installing / Getting started

The best way to obtain the library is via the [DataTablePrettyPrinter NuGet package](https://www.nuget.org/packages/DataTablePrettyPrinter/):
 
```shell
dotnet add package DataTablePrettyPrinter
```

Alternatively you may clone this git repository and build the library for use within your projects:

```shell
dotnet build
```

## Visual Overview

The following mock table is an overview of the different areas of the `DataTable` which are displayed. The `TableName` and `ColumnName` values map directly onto their `DataTable.TableName` and `DataColumn.ColumnName` properties. The data area displays the row contents of the table.

```
+---------------------------------------------------+
|                     TableName                     |
+------------+------------+------------+------------+
| ColumnName | ColumnName | ColumnName | ColumnName |
+------------+------------+------------+------------+
|            |            |            |            |
|            |            |            |            |
|    Data    |    Data    |    Data    |    Data    |
|    Area    |    Area    |    Area    |    Area    |
|            |            |            |            |
|            |            |            |            |
+------------+------------+------------+------------+
```

## Examples

To demonstrate the capabilities and ease of use of this library we will use a simple data table:

```csharp
using DataTablePrettyPrinter;

DataTable table = new DataTable("Prescriptions");

table.Columns.Add("Dosage", typeof(Int32));
table.Columns.Add("Drug", typeof(String));
table.Columns.Add("Patient", typeof(String));
table.Columns.Add("Date", typeof(DateTime));

table.Rows.Add(25, "Indocin", "David", DateTime.Parse("5/1/2008 12:30:52 PM"));
table.Rows.Add(50, "Enebrel", "Sam", DateTime.Parse("9/11/2008 8:42:30 AM"));
table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Parse("12/12/2019 9:15:00 AM"));
table.Rows.Add(21, "Combivent", "Janet", DateTime.Parse("12/8/2018 3:00:00 PM"));
table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Parse("9/14/2020 4:44:44 PM"));
```

### Default pretty printing

Default pretty printing is as easy as calling the `ToPrettyPrintedString` extension method:

```csharp
Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+-----------------------------------------------------------+
|                       Prescriptions                       |
+--------+-------------+-----------+------------------------+
| Dosage |    Drug     |  Patient  |          Date          |
+--------+-------------+-----------+------------------------+
| 25     | Indocin     | David     | 2008-05-01 12:30:52 PM |
| 50     | Enebrel     | Sam       | 2008-09-11 8:42:30 AM  |
| 10     | Hydralazine | Christoff | 2019-12-12 9:15:00 AM  |
| 21     | Combivent   | Janet     | 2018-12-08 3:00:00 PM  |
| 100    | Dilantin    | Melanie   | 2020-09-14 4:44:44 PM  |
+--------+-------------+-----------+------------------------+
```

### Controlling borders

Borders of the entire table or individual columns can be fully controlled. The library allows you to specify borders with a flags `enum`. We can for example disable drawing of side columns:


```csharp
table.SetBorder(Border.Top | Border.Left);

table.Columns[0].SetHeaderBorder(Border.Top);
table.Columns[1].SetHeaderBorder(Border.Bottom | Border.Left);
table.Columns[2].SetHeaderBorder(Border.Bottom | Border.Left);
table.Columns[3].SetHeaderBorder(Border.Bottom | Border.Left);

table.Columns[0].SetDataBorder(Border.None);
table.Columns[1].SetDataBorder(Border.Left);
table.Columns[2].SetDataBorder(Border.Left);
table.Columns[3].SetDataBorder(Border.Left);

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```

                        Prescriptions
         +             +           +
  Dosage |    Drug     |  Patient  |          Date
+--------+-------------+-----------+------------------------+
  25     | Indocin     | David     | 2008-05-01 12:30:52 PM
  50     | Enebrel     | Sam       | 2008-09-11 8:42:30 AM
  10     | Hydralazine | Christoff | 2019-12-12 9:15:00 AM
  21     | Combivent   | Janet     | 2018-12-08 3:00:00 PM
  100    | Dilantin    | Melanie   | 2020-09-14 4:44:44 PM
         +             +           +
```

We can also showcase the type of flexibility the library allows:

```csharp
table.SetBorder(Border.Top | Border.Left);

table.Columns[0].SetHeaderBorder(Border.None);
table.Columns[1].SetHeaderBorder(Border.Left | Border.Top | Border.Right);
table.Columns[2].SetHeaderBorder(Border.None);
table.Columns[3].SetHeaderBorder(Border.Left | Border.Top);

table.Columns[0].SetDataBorder(Border.Bottom | Border.Right);
table.Columns[1].SetDataBorder(Border.None);
table.Columns[2].SetDataBorder(Border.Left | Border.Bottom);
table.Columns[3].SetDataBorder(Border.Left);

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+-----------------------------------------------------------+
|                       Prescriptions
|        +-------------+           +------------------------+
| Dosage |    Drug     |  Patient  |          Date
|        +             +           +
| 25     | Indocin     | David     | 2008-05-01 12:30:52 PM
| 50     | Enebrel     | Sam       | 2008-09-11 8:42:30 AM
| 10     | Hydralazine | Christoff | 2019-12-12 9:15:00 AM
| 21     | Combivent   | Janet     | 2018-12-08 3:00:00 PM
| 100    | Dilantin    | Melanie   | 2020-09-14 4:44:44 PM
+--------+             +-----------+
```

### Controlling the display of table name and column headers

We can fully control whether to display the table name, or each individual column header:


```csharp
table.SetShowTableName(false);

table.Columns[1].SetShowColumnName(false);
table.Columns[3].SetShowColumnName(false);

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+--------+-------------+-----------+------------------------+
| Dosage |             |  Patient  |                        |
+--------+-------------+-----------+------------------------+
| 25     | Indocin     | David     | 2008-05-01 12:30:52 PM |
| 50     | Enebrel     | Sam       | 2008-09-11 8:42:30 AM  |
| 10     | Hydralazine | Christoff | 2019-12-12 9:15:00 AM  |
| 21     | Combivent   | Janet     | 2018-12-08 3:00:00 PM  |
| 100    | Dilantin    | Melanie   | 2020-09-14 4:44:44 PM  |
+--------+-------------+-----------+------------------------+
```

### Controlling text alignment of column names and data

The library has support for controlling text alignment:


```csharp
table.SetTitleTextAlignment(TextAlignment.Left);

table.Columns[0].SetColumnNameAlignment(TextAlignment.Right);
table.Columns[1].SetColumnNameAlignment(TextAlignment.Left);

table.Columns[0].SetDataAlignment(TextAlignment.Center);
table.Columns[2].SetDataAlignment(TextAlignment.Right);

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+-----------------------------------------------------------+
| Prescriptions                                             |
+--------+-------------+-----------+------------------------+
| Dosage | Drug        |  Patient  |          Date          |
+--------+-------------+-----------+------------------------+
|   25   | Indocin     |     David | 2008-05-01 12:30:52 PM |
|   50   | Enebrel     |       Sam | 2008-09-11 8:42:30 AM  |
|   10   | Hydralazine | Christoff | 2019-12-12 9:15:00 AM  |
|   21   | Combivent   |     Janet | 2018-12-08 3:00:00 PM  |
|  100   | Dilantin    |   Melanie | 2020-09-14 4:44:44 PM  |
+--------+-------------+-----------+------------------------+
```

### Controlling column widths

The library automatically sizes column widths based on the maximum width of any individual row. However the user can override this if it happens that the data may be too wide to display in a readable format. In such cases we can explicitly set the column widths:


```csharp
table.Columns[1].SetWidth(8);
table.Columns[3].SetWidth(33);

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+---------------------------------------------------------------+
|                         Prescriptions                         |
+--------+--------+-----------+---------------------------------+
| Dosage |  Drug  |  Patient  |              Date               |
+--------+--------+-----------+---------------------------------+
| 25     | Indo.. | David     | 2008-05-01 12:30:52 PM          |
| 50     | Eneb.. | Sam       | 2008-09-11 8:42:30 AM           |
| 10     | Hydr.. | Christoff | 2019-12-12 9:15:00 AM           |
| 21     | Comb.. | Janet     | 2018-12-08 3:00:00 PM           |
| 100    | Dila.. | Melanie   | 2020-09-14 4:44:44 PM           |
+--------+--------+-----------+---------------------------------+
```

Note that ellipses (`..`) are added if the string cannot be contained within the width requested.

### Custom formatting

By default the library calls the `ToString` API to convert the row objects into strings, however sometimes we require custom printing. The library supports arbitrary control of the string to be printed via a method callback which the user supplies. In this example we want to put an asterisk next to a dosage which exceeds 23 units. We can do this as follows:

```csharp
table.Columns[0].SetDataTextFormat((DataColumn c, DataRow r) =>
{
    Int32 value = r.Field<Int32>(c);

    return value > 23 ? $"{value} (*)" : $"{value}";
});

Console.WriteLine(table.ToPrettyPrintedString());
```

Output:

```
+------------------------------------------------------------+
|                       Prescriptions                        |
+---------+-------------+-----------+------------------------+
| Dosage  |    Drug     |  Patient  |          Date          |
+---------+-------------+-----------+------------------------+
| 25 (*)  | Indocin     | David     | 2008-05-01 12:30:52 PM |
| 50 (*)  | Enebrel     | Sam       | 2008-09-11 8:42:30 AM  |
| 10      | Hydralazine | Christoff | 2019-12-12 9:15:00 AM  |
| 21      | Combivent   | Janet     | 2018-12-08 3:00:00 PM  |
| 100 (*) | Dilantin    | Melanie   | 2020-09-14 4:44:44 PM  |
+---------+-------------+-----------+------------------------+
```

## Tests

A set of unit tests covers all features of the library by comparing the result against a hand verified output. To run the tests simply:

```shell
dotnet build
dotnet test
```