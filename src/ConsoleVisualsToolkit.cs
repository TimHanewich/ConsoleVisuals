using System;

namespace ConsoleVisuals
{
    public class ConsoleVisualsToolkit
    {
        public static void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }

        //Change only the foreground
        public static void WriteLine(string msg, ConsoleColor foreground)
        {
            ConsoleColor oc = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.WriteLine(msg);
            Console.ForegroundColor = oc;
        }

        public static void WriteLine(string msg, ConsoleColor foreground, ConsoleColor background)
        {
            ConsoleColor orgF = Console.ForegroundColor;
            ConsoleColor orgB = Console.BackgroundColor;

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.WriteLine(msg);

            Console.ForegroundColor = orgF;
            Console.BackgroundColor = orgB;
        }
    }
}