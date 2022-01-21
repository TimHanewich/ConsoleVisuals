using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleVisuals
{
    public class ConsoleLoadBar
    {
        private int BarWidth;
        

        public static ConsoleLoadBar Create(int? width = null)
        {
            ConsoleLoadBar ToReturn = new ConsoleLoadBar();

            if (width.HasValue)
            {
                ToReturn.BarWidth = width.Value;
            }
            else
            {
                List<int> Save = new List<int>();
                Save.Add(2); //For the brackets
                Save.Add(1); //For the space
                Save.Add(3); //For the three digits max (i.e. 50, 75, 100)
                Save.Add(1); //For the percentage sign
                ToReturn.BarWidth = Console.WindowWidth - Save.Sum();
            }

            return ToReturn;
        }
    
        public string GenerateLoadBar(float percentage)
        {
            if (percentage < 0 || percentage > 1)
            {
                throw new Exception("Percentage must be >= 0 and <= 1");
            }

            float EachTickIs = 1f / (float)BarWidth;
            int ticks = Convert.ToInt32(Math.Floor(percentage / EachTickIs));
            int blank_ticks = BarWidth - ticks;

            int t = 0;

            //Write the bar
            string ToReturn = "[";
            for (t=0;t<ticks;t++)
            {
                ToReturn = ToReturn + "■";
            }
            for (t=0;t<blank_ticks;t++)
            {
                ToReturn = ToReturn + " ";
            }
            ToReturn = ToReturn + "]";

            //Write the percentage
            ToReturn = ToReturn + " ";
            ToReturn = ToReturn + percentage.ToString("##0%");

            return ToReturn;
        }
    }
}