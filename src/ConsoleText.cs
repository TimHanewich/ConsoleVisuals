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

        public ConsoleText(string text)
        {
            Text = text;
        }

        public ConsoleText(string text, ConsoleColor foreground)
        {
            Text = text;
            Foreground = foreground;
        }

        public ConsoleText(string text, ConsoleColor foreground, ConsoleColor background)
        {
            Text = text;
            Foreground = foreground;
            Background = background;
        }
    }
}