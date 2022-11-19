using System;
using ConsoleVisuals;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsoleText ct_Month = new ConsoleText();
            ConsoleText ct_Day = new ConsoleText();
            ConsoleText ct_Hour = new ConsoleText();
            ConsoleText ct_Minute = new ConsoleText();
            ConsoleText ct_Second = new ConsoleText();
            ConsoleDisplay cd = new ConsoleDisplay();
            cd.AddLine(new ConsoleText("Month: "), ct_Month);
            cd.AddLine(new ConsoleText("Day: "), ct_Day);
            cd.AddLine(new ConsoleText("Hour: "), ct_Hour);
            cd.AddLine(new ConsoleText("Minute: "), ct_Minute);
            cd.AddLine(new ConsoleText("Second: "), ct_Second);

            while (true)
            {
                DateTime now = DateTime.UtcNow;
                ct_Month.Text = now.Month.ToString();
                ct_Day.Text = now.Day.ToString();
                ct_Hour.Text = now.Hour.ToString();
                ct_Minute.Text = now.Minute.ToString();
                ct_Second.Text = now.Second.ToString();
                cd.UpdateDisplay();
                Task.Delay(1000).Wait();
            }
        }
        
    }
}
