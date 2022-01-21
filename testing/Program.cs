using System;
using ConsoleVisuals;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleVisualsToolkit.WriteLine("Hello, world!");
            ConsoleVisualsToolkit.WriteLine("Hello, world", ConsoleColor.Red);
            ConsoleVisualsToolkit.WriteLine("Hiii", ConsoleColor.Blue, ConsoleColor.Red);
            Console.WriteLine("Testing.");
            ConsoleVisualsToolkit.WriteLine("Testing 123");
        }
    }
}
