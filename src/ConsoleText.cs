using System;

namespace ConsoleVisuals
{
    public class ConsoleText
    {
        public string Text {get; set;}
        public ConsoleColor? Foreground {get; set;}
        public ConsoleColor? Background {get; set;}

        public ConsoleText()
        {
            Foreground = null;
            Background = null;
        }
    }
}