using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace cookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                running = MainMenu();
            }
        }

        //Main menu with all options - selection by 
        static bool MainMenu()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Clear();
            Console.Title = "cookBook";
            Console.WriteLine("Press a key to choose an option:\n");
            Console.WriteLine(" [A]dd new recipe");
            Console.WriteLine(" [E]dit recipe");
            Console.WriteLine(" [D]elete recipe");
            Console.WriteLine(" [L]ist all recipes");
            Console.WriteLine(" [Q]uit");

            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                    AddNewRecipe();
                    return true;
                case ConsoleKey.E:
                    EditRecipe();
                    return true;
                case ConsoleKey.D:
                    DeleteRecipe();
                    return true;
                case ConsoleKey.L:
                    ListAllRecipes();
                    return true;
                case ConsoleKey.Q:
                    return false;
            }
            return true;
        }

        static void AddNewRecipe()
        {
            Console.Title = "cookBook - Add new recipe";
            UnderConstructionScreen();
        }

        static void EditRecipe()
        {
            Console.Title = "cookBook - Edit recipe";
            UnderConstructionScreen();
        }

        static void DeleteRecipe()
        {
            Console.Title = "cookBook - Delete recipe";
            UnderConstructionScreen();
        }

        static void ListAllRecipes()
        {
            Console.Title = "cookBook - List all recipes";
            UnderConstructionScreen();
        }
        static void UnderConstructionScreen()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Section Under Construction - press any key to return to menu...");
            Console.ReadKey(true);
        }
    }
}
