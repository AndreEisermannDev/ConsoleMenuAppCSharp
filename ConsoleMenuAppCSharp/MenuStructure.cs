using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuAppCSharp
{
    internal class MenuStructure
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public MenuStructure(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefixL;
                string prefixR;
                if (i == SelectedIndex)
                {
                    prefixL = ">";
                    prefixR = "<";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    prefixL = " ";
                    prefixR = " ";
                }
                Console.WriteLine($"[{prefixL}{currentOption}{prefixR}]");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            Console.Clear();
            ConsoleKey keyPressed;
            do
            {
                Console.SetCursorPosition(0, 0);
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}

