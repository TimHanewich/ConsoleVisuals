using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleVisuals
{
    public class ConsoleTable
    {
        private string[] ColumnTitles;
        private List<TableCellContent[]> Rows;

        public ConsoleTable()
        {
            Rows = new List<TableCellContent[]>();
            ColumnTitles = new string[] { };
        }

        public static ConsoleTable Create(params string[] column_titles)
        {
            if (column_titles.Length == 0)
            {
                throw new Exception("There must be at least 1 column in the table");
            }

            ConsoleTable ToReturn = new ConsoleTable();
            ToReturn.ColumnTitles = column_titles;
            return ToReturn;
        }
    
        public void AddRow(params TableCellContent[] content)
        {
            if (content.Length != ColumnTitles.Length)
            {
                throw new Exception("Number of columns in the supplied row did not match the number of columns in the header row.");
            }

            Rows.Add(content);
        }

        public void AddRow(params string[] content)
        {
            List<TableCellContent> TCCs = new List<TableCellContent>();
            foreach (string s in content)
            {
                TableCellContent tcc = new TableCellContent();
                tcc.Text = s;
                tcc.ForegroundColor = Console.ForegroundColor;
                tcc.Alignment = CellContentAlignment.Center;

                TCCs.Add(tcc);
            }
            AddRow(TCCs.ToArray());
        }

        public void WriteTable(bool include_text_buffer = false)
        {
            if (ColumnTitles.Length == 0)
            {
                throw new Exception("Unable to create a table with 0 columns.");
            }

            //Create a new list to print from
            List<TableCellContent[]> ToPrint = new List<TableCellContent[]>();
            foreach (TableCellContent[] tccs in Rows)
            {
                List<TableCellContent> ThisRow = new List<TableCellContent>();
                foreach (TableCellContent tcc in tccs)
                {
                    ThisRow.Add(tcc.Copy());
                }
                ToPrint.Add(ThisRow.ToArray());
            }


            //Add the header to the rows to print
            List<TableCellContent> HeaderRow = new List<TableCellContent>();
            foreach (string s in ColumnTitles)
            {
                HeaderRow.Add(new TableCellContent { Text = s, ForegroundColor = Console.ForegroundColor, Alignment = CellContentAlignment.Center });
            }
            ToPrint.Insert(0, HeaderRow.ToArray());


            //If it is set to include text buffer, add it now
            foreach (TableCellContent[] tccs in ToPrint)
            {
                foreach (TableCellContent tcc in tccs)
                {
                    tcc.Text = " " + tcc.Text + " ";
                }
            }

            //Get length for each
            List<int> ColumnMaxWidths = new List<int>();
            int t = 0;
            for (t=0;t<ColumnTitles.Length;t++)
            {
                int MaxWidth = 0;
                foreach (TableCellContent[] row_content in ToPrint)
                {
                    if (row_content[t].Text.Length > MaxWidth)
                    {
                        MaxWidth = row_content[t].Text.Length;
                    }
                }
                ColumnMaxWidths.Add(MaxWidth);
            }

            //Write the top table line
            int NumberOfVerticalDividers = ColumnTitles.Length + 1;
            Console.WriteLine("┌" + new string('─', ColumnMaxWidths.Sum() + NumberOfVerticalDividers - 2) + "┐");

            


            //Write the rows
            t = 0;
            for (t=0;t<ToPrint.Count;t++)
            {
                int c = 0;
                for (c=0;c<ToPrint[t].Length;c++)
                {
                    TableCellContent tcc = ToPrint[t][c];

                    //Write the divider
                    Console.Write("│");

                    //Record the current color
                    ConsoleColor CurrentColor = Console.ForegroundColor;


                    //Change the color to what is desired
                    Console.ForegroundColor = tcc.ForegroundColor;

                    if (tcc.Alignment == CellContentAlignment.Left)
                    {
                        Console.Write(tcc.Text);
                        if (ColumnMaxWidths[c] > tcc.Text.Length)
                        {
                            Console.Write(new string(' ', ColumnMaxWidths[c] - tcc.Text.Length));
                        }
                    }
                    else if (tcc.Alignment == CellContentAlignment.Center)
                    {
                        int CharGap = ColumnMaxWidths[c] - tcc.Text.Length;
                        float EachSide = (float)CharGap / (float)2;
                        int FirstGap = Convert.ToInt32(Math.Floor(EachSide));
                        int SecondGap = CharGap - FirstGap;
                        string ToWriteForThisCell =  new string(' ', FirstGap) + tcc.Text + new string(' ', SecondGap);
                        Console.Write(ToWriteForThisCell);
                    }

                    //Change the color to what it was previously
                    Console.ForegroundColor = CurrentColor;

                }

                //Write the last vertical divider for the last cell
                Console.Write("│");



                //Write the next row divider
                Console.WriteLine();
                if (t != ToPrint.Count-1) //Print a straight line if it is not the last row
                {
                    //Console.WriteLine(new string('─', ColumnMaxWidths.Sum() + NumberOfVerticalDividers));
                    Console.WriteLine("├" + new string('─', ColumnMaxWidths.Sum() + NumberOfVerticalDividers - 2) + "┤");
                }
                else //Print a straight line with edges if it is the last row
                {
                    Console.WriteLine("└" + new string('─', ColumnMaxWidths.Sum() + NumberOfVerticalDividers - 2) + "┘");
                }

            }

        }

    }
}