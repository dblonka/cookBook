using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookBook
{ 
    class InputOutput
    {
        static RecipeManager recipeBook = new RecipeManager();

        //Main menu with all options - selection by 
        public bool MainMenu()
        {
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Clear();
            Console.Title = "cookBook";
            Console.WriteLine("Cookbook contains: " + recipeBook.AmountOfRecipes() + " recipes");
            Console.WriteLine("Press a key to choose an option:\n");
            Console.WriteLine(" [A]dd new recipe");
            Console.WriteLine(" [E]dit recipe");
            Console.WriteLine(" [D]elete recipe");
            Console.WriteLine(" [L]ist all recipes");
            Console.WriteLine(" [Q]uit");

            switch (Console.ReadKey(true).Key)
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
            FreshConsole("cookBook - Add new recipe", "Provide name for new recipe");
            string name = Console.ReadLine();
            Console.WriteLine("Provide descritpion for new recipe: ");
            string desc = Console.ReadLine();

            recipeBook.AddRecipe(new Recipe(name, desc));
        }

        static void EditRecipe()
        {
            FreshConsole("cookBook - Edit recipe", "Provide name of recipe to edit");
            string name = Console.ReadLine();
            if (recipeBook.RecipeExists(name))
            {
                Console.WriteLine("Provide new name for a recipe");
                string newName = Console.ReadLine();
                recipeBook.EditRecipe(recipeBook.SelectRecipe(name), newName);
            }
        }

        static void DeleteRecipe()
        {
            FreshConsole("cookBook - Delete recipe", "Provide name of recipe to delete");
            string name = Console.ReadLine();
            Console.WriteLine(recipeBook.ShowRecipe(name));
            if (Confirmation("Are you sure you want to delete this recipe? [Y/N]"))
            {
                recipeBook.DeleteRecipe(name);
            }
        }

        static void ListAllRecipes()
        {
            FreshConsole("cookBook - List all recipes", "");
            List<string> tableOfContents = recipeBook.TableOfContents();
            foreach (string item in tableOfContents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to return to Menu");
            Console.ReadKey(true);
        }
        static void UnderConstructionScreen()
        {
            FreshConsole("Under construction", "Section Under Construction - press any key to return to menu...");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.ReadKey(true);
        }

        static bool Confirmation(string message)
        {
            bool result = false;
            bool loop = true;
            Console.WriteLine(message);
            while (loop)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        result = true;
                        loop = false;
                        break;
                    case ConsoleKey.N:
                        result = false;
                        loop = false;
                        break;
                }
            }
            return result;
        }

        static void FreshConsole(string title, string line)
        {
            Console.Clear();
            if (title.Length > 0)
            {
                Console.Title = title;
            } 
            else
            {
                Console.Title = "";
            }
            if (line.Length > 0)
            {
                Console.WriteLine(line);
            }

        }
    }
}
