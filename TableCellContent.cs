using System;

namespace ConsoleVisuals
{
    public class TableCellContent
    {
        public string Text { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public CellContentAlignment Alignment { get; set; }

        public TableCellContent()
        {
            Text = null;
            ForegroundColor = Console.ForegroundColor;
            Alignment = CellContentAlignment.Left;
        }
        
        public TableCellContent Copy()
        {
            TableCellContent ToReturn = new TableCellContent();

            ToReturn.Text = Text;
            ToReturn.ForegroundColor = ForegroundColor;
            ToReturn.Alignment = Alignment;

            return ToReturn;
        }

        
    }
}