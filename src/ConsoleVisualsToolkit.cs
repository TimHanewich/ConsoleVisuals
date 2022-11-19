using System;

namespace ConsoleVisuals
{
    public class ConsoleVisualsToolkit
    {

        #region "write"

        public static void Write(string msg)
        {
            Console.Write(msg);
        }

        //Change only the foreground
        public static void Write(string msg, ConsoleColor foreground)
        {
            ConsoleColor oc = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.Write(msg);
            Console.ForegroundColor = oc;
        }

        public static void Write(string msg, ConsoleColor foreground, ConsoleColor background)
        {
            ConsoleColor orgF = Console.ForegroundColor;
            ConsoleColor orgB = Console.BackgroundColor;

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;

            Console.Write(msg);

            Console.ForegroundColor = orgF;
            Console.BackgroundColor = orgB;
        }

        #endregion

        #region "write line"

        public static void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

        public static void WriteLine(string msg, ConsoleColor foreground)
        {
            Write(msg + Environment.NewLine, foreground);
        }

        public static void WriteLine(string msg, ConsoleColor foreground, ConsoleColor background)
        {
            Write(msg + Environment.NewLine, foreground, background);
        }

        
    

        #endregion
        
    }
}