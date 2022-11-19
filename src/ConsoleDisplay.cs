using System;
using System.Collections.Generic;

namespace ConsoleVisuals
{
    public class ConsoleDisplay
    {
        private List<ConsoleText[]> Lines;

        public ConsoleDisplay()
        {
            Lines = new List<ConsoleText[]>();
        }

        public void AddLine(params ConsoleText[] texts)
        {
            Lines.Add(texts);
        }
        
        public void AddLines(ConsoleText[][] lines)
        {
            foreach (ConsoleText[] line in lines)
            {
                AddLine(line);
            }
        }
    
    
    
        public void UpdateDisplay()
        {
            Console.Clear();

            foreach (ConsoleText[] line in Lines)
            {
                //Go through each part
                foreach (ConsoleText text in line)
                {
                    ConsoleVisualsToolkit.Write(text);
                }
                Console.WriteLine(); //Next line
            }
        }
    
    }
}