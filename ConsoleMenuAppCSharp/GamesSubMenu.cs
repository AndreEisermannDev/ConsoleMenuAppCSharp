using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenuAppCSharp
{
    internal class GamesSubMenu
    {
        public void GamesMenuStart()
        {
            string prompt = @"   _____                           
  / ____|                          
 | |  __  __ _ _ __ ___   ___  ___ 
 | | |_ |/ _` | '_ ` _ \ / _ \/ __|
 | |__| | (_| | | | | | |  __/\__ \
  \_____|\__,_|_| |_| |_|\___||___/
                                   
                                   ";
            string[] options = { "Random Number Guessing", "Back to Main Menu" };

            MenuStructure gamesMenu = new MenuStructure(prompt, options);
            int selectedIndex = gamesMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RandomNumberGuessing();
                    break;
                case 1:
                    MainMenu myGame = new MainMenu();
                    myGame.Start();
                    break;
            }

            void RandomNumberGuessing()
            {
                Console.Clear();
                string numberGuesserPrompt = @"  _____                 _                   _   _                 _               
 |  __ \               | |                 | \ | |               | |              
 | |__) |__ _ _ __   __| | ___  _ __ ___   |  \| |_   _ _ __ ___ | |__   ___ _ __ 
 |  _  // _` | '_ \ / _` |/ _ \| '_ ` _ \  | . ` | | | | '_ ` _ \| '_ \ / _ \ '__|
 | | \ \ (_| | | | | (_| | (_) | | | | | | | |\  | |_| | | | | | | |_) |  __/ |   
 |_|  \_\__,_|_| |_|\__,_|\___/|_| |_| |_| |_| \_|\__,_|_| |_| |_|_.__/ \___|_|   
                                                                                  
                                                                                  
Guess the number between 1 and 10: ";
                Console.WriteLine(numberGuesserPrompt);
                Random randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(1, 10);
                int userGuess = 0; //assign to 0 because try catch portion will throw error otherwise
                do
                {

                    try
                    {
                        userGuess = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {

                        Console.WriteLine("Please enter a valid input!");
                    }

                    if (userGuess < randomNumber)
                    {

                        Console.WriteLine("Your guess was too low.");
                    }
                    else if (userGuess > randomNumber)
                    {
                        Console.WriteLine("Your guess was too high.");
                    }
                    else
                    {
                        Console.WriteLine($"Correct! {userGuess} was the number.");
                    }
                } while (userGuess != randomNumber);
                Console.WriteLine("\n(Enter to return to menu)");
                Console.ReadLine();
                GamesMenuStart();
                Console.Clear();
            }


        }
    }
}
