using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleMenuAppCSharp
{
    internal class ToDoList
    {
        public void ToDoListApp()
        {
            string prompt = "";
            string[] options = { "View Tasks", "Add Task", "Delete Task", "Exit" };
            MenuStructure toDoMenu = new MenuStructure(prompt, options);
            int selectedIndex = toDoMenu.Run();
            Console.Clear();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("View Tasks");
                    ToDoList readToDos = new ToDoList();
                    readToDos.ToDoFileRead();
                    break;
                case 1:
                    Console.WriteLine("Add Task");
                    Console.WriteLine("Name the task: ");
                    string taskName = Console.ReadLine();
                    string dateInput = "";
                    IsValidDateTime(dateInput);
                    while (IsValidDateTime(dateInput) == false)
                    {
                        Console.WriteLine("Enter a date when task should be completed (DD.MM.YYYY hh:mm:ss): ");
                        dateInput = Console.ReadLine();
                    }
                    DateTime validDate = Convert.ToDateTime(dateInput);
                    ToDoFileAdd(taskName, validDate);
                    Console.WriteLine($"added '{taskName}' due to {validDate}");
                    break;
                case 2:
                    Console.WriteLine("Delete Task");
                    ToDoFileRemoveMenu();
                    break;
                case 3:
                    UtilitySubMenu utilMenu = new UtilitySubMenu();
                    utilMenu.UtilityStart();
                    break;
            }
            Console.WriteLine("\n(Enter to return to menu)");
            Console.ReadLine();
            ToDoListApp();
        }

        public string ToDoListTitle { get; set; }
        public DateTime ToDoListTime { get; set; }

        public void ToDoFileRead()
        {
            string toDoFilePath = @"C:\Users\Administrator\source\repos\GitHub\ConsoleMenuAppCSharp\ConsoleMenuAppCSharp\ToDoListItems.txt";
            List<string> lines = File.ReadAllLines(toDoFilePath).ToList();

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        public void ToDoFileAdd(string taskName,DateTime taskDate)
        {
            string toDoFilePath = @"C:\Users\Administrator\source\repos\GitHub\ConsoleMenuAppCSharp\ConsoleMenuAppCSharp\ToDoListItems.txt";
            List<string> lines = File.ReadAllLines(toDoFilePath).ToList();
            lines.Add($"{taskName,20}, {taskDate}");
            File.WriteAllLines(toDoFilePath, lines);
        }

        public void ToDoFileRemoveMenu()
        {
            string toDoFilePath = @"C:\Users\Administrator\source\repos\GitHub\ConsoleMenuAppCSharp\ConsoleMenuAppCSharp\ToDoListItems.txt";
            int lineCount = Convert.ToInt32(File.ReadLines(toDoFilePath).Count());
            List<string> lines = File.ReadAllLines(toDoFilePath).ToList();

            string prompt = "Select an entry to delete";
            string[] options = new string[lineCount];

            int optionsIndex = 0;
            foreach (string line in lines)
            {
                
                options[optionsIndex] = line;
                optionsIndex++;                    
            }



            MenuStructure toDoRemoveMenu = new MenuStructure(prompt, options);
            int selectedIndex = toDoRemoveMenu.Run();
            lines.RemoveAt(selectedIndex);
            File.WriteAllLines(toDoFilePath, lines);
        }

        public static bool IsValidDateTime(string date)
        {
            DateTime tempDate;
            return DateTime.TryParse(date, out tempDate);
        }
    }
}
