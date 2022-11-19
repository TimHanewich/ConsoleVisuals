using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleVisuals
{
    public class ConsoleDisplay
    {

        //Private tracking
        private List<ConsoleText[]> Lines;
        private bool PrintedOnce;
        private ConsoleText[][] LastDisplayed;

        public ConsoleDisplay()
        {
            Lines = new List<ConsoleText[]>();
            PrintedOnce = false;
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


            if (PrintedOnce == false) //If this is the first time we are printing it, clear + print raw
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
                PrintedOnce = true;
            }
            else //It was already been printed
            {
                if (Lines.Count != LastDisplayed.Length) //if entire lines were added or removed since the last time, just rewrite entirely
                {
                    PrintedOnce = false;
                    UpdateDisplay();
                    return;
                }
                else
                {
                    for (int l = 0; l < Lines.Count; l++)
                    {
                        ConsoleText[] LastLine = LastDisplayed[l];
                        ConsoleText[] NewLine = Lines[l];


                        //Character location
                        int CharcterLocation = 0;

                        for (int t = 0; t < LastLine.Length; t++)
                        {
                            ConsoleText LastText = LastLine[t];
                            ConsoleText NewText = NewLine[t];

                            if (ConsoleTextsIdentical(LastText, NewText) == false)
                            {
                                Console.CursorTop = l; //Go to the proper line
                                Console.CursorLeft = CharcterLocation; //Go to the proper location
                                ConsoleVisualsToolkit.Write(NewText); //Write it

                                //If the new text is shorter than the old text, fill in the remainder of the space that WAS used with empty spaces (to clear it out)
                                if (NewText.Text.Length < LastText.Text.Length)
                                {
                                    int CharacterDifference = LastText.Text.Length - NewText.Text.Length;
                                    ConsoleVisualsToolkit.Write(new string(' ', CharacterDifference));
                                }
                            }

                            //Incremented character location
                            CharcterLocation = CharcterLocation + NewText.Text.Length;
                        }
                    }
                }
            }

            //Save a snapshot copy
            LastDisplayed = CopyDisplay();
        }
    

        #region  "resources for comparing changes"

        private ConsoleText[][] CopyDisplay()
        {
            List<ConsoleText[]> ToReturn = new List<ConsoleText[]>();
            foreach (ConsoleText[] line in Lines)
            {
                List<ConsoleText> LineCopy = new List<ConsoleText>();
                foreach (ConsoleText text in line)
                {
                    ConsoleText TextCopy = new ConsoleText();
                    TextCopy.Text = text.Text;
                    TextCopy.Foreground = text.Foreground;
                    TextCopy.Background = text.Background;
                    LineCopy.Add(TextCopy);
                }
                ToReturn.Add(LineCopy.ToArray());
            }
            return ToReturn.ToArray();
        }

        private bool ConsoleTextsIdentical(ConsoleText t1, ConsoleText t2)
        {
            if (t1.Text != t2.Text)
            {
                return false;
            }
            else if (t1.Foreground != t2.Foreground)
            {
                return false;
            }
            else if (t1.Background != t2.Background)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}