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
        }
        public void SimpleCalculator()
        {
            Console.Clear();
            Console.WriteLine("Calculator");
            
            Console.WriteLine("\nEnter a number: ");
            double userNumber1 = int.Parse(Console.ReadLine());
            Console.WriteLine("\n Enter an operator: (/ * + -)");
            char userOperator = char.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter another number: ");
            double userNumber2 = int.Parse(Console.ReadLine());

            double result = 0;
            switch (userOperator)
            {
                case '/':
                    result = userNumber1 / userNumber2;
                    break;
                case '*':
                    result = userNumber1 * userNumber2;
                    break;
                case '-':
                    result = userNumber1 - userNumber2;
                    break;
                case '+':
                    result = userNumber1 + userNumber2;
                    break;
            }
            Console.WriteLine($"{userNumber1} {userOperator} {userNumber2} = {result}");
            Console.WriteLine("\n(Enter to return to menu)");
            Console.ReadLine();

            UtilityStart(); //returning to previous menu
            Console.Clear();
        }
    }
}

