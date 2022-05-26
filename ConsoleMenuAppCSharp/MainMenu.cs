using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleMenuAppCSharp
{
    internal class MainMenu
    {
        public void Start()
        {
            Console.Title = "Multi Purpose Menu Application";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"  __  __       _         __  __                  
 |  \/  |     (_)       |  \/  |                 
 | \  / | __ _ _ _ __   | \  / | ___ _ __  _   _ 
 | |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
 | |  | | (_| | | | | | | |  | |  __/ | | | |_| |
 |_|  |_|\__,_|_|_| |_| |_|  |_|\___|_| |_|\__,_|
                                                 
                                                 
(use arrow keys to navigate | enter to submit)
";
            string[] options = { "Games", "Utility", "Exit" };
            MenuStructure mainMenu = new MenuStructure(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Games();
                    break;              //amount of statements need to match amount of options of options array!
                case 1:
                    UtilityApps();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }

        private void Games()
        {
            Console.Clear();
            GamesSubMenu myGamesSubMenu = new GamesSubMenu();
            myGamesSubMenu.GamesMenuStart();
        }
        private void UtilityApps()
        {
            Console.Clear();
            UtilitySubMenu myUtilitySubMenu = new UtilitySubMenu();
            myUtilitySubMenu.UtilityStart();
        }
        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("Shutting down..");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
    }
}

