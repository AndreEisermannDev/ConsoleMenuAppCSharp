using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuAppCSharp
{
    internal class UtilitySubMenu
    {
        public void UtilityStart()
        {
            string prompt = @"  _    _ _   _ _ _ _         
 | |  | | | (_) (_) |        
 | |  | | |_ _| |_| |_ _   _ 
 | |  | | __| | | | __| | | |
 | |__| | |_| | | | |_| |_| |
  \____/ \__|_|_|_|\__|\__, |
                        __/ |
                       |___/ 

";
            string[] options = { "Simple Calculator", "Back to Main Menu" };

            MenuStructure gamesMenu = new MenuStructure(prompt, options);
            int selectedIndex = gamesMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    SimpleCalculator();
                    break;
                case 1:
                    MainMenu myGame = new MainMenu();
                    myGame.Start();
                    break;
            }

            void SimpleCalculator()
            {
                Console.Clear();
                Console.WriteLine("Test");
                Console.ReadLine();
                UtilityStart();
                Console.Clear();
            }
        }
    }
}

