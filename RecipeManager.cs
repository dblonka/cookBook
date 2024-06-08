using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cookBook
{
    internal class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public int CountEntries(string name)
        {
            return recipes.GroupBy(recipe => recipe.Name).Where(group => group.Count() > 1).Sum(group => group.Count());
        }

        public Recipe FindSingle(string name)
        {
            if (recipes.Any())
            {
                var matches = recipes.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matches.Count() == 0)
                {
                    return null;
                }
                else if (matches.Count() == 1)
                {
                    return recipes.Find(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    int i = 1;
                    int selection = 0;
                    Console.WriteLine("Multiple recipes found - select one\n");
                    foreach (var element in matches)
                    {
                        Console.WriteLine(i + ".\t" + element.Name + " " + element.Descritpion);
                        i++;
                    }
                    while(true)
                    {
                        if (int.TryParse(Console.ReadLine(), out selection) && selection > 0 && selection <= matches.Count())
                        {
                            return matches[selection - 1];
                        } 
                        else
                        {
                            Console.WriteLine("Incorrect input");
                        }
                    }
                }
            }
            else
            {
                return null;
            }
        }


        public bool AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            return true;
        }

        public bool Confirm(string query)
        {
            bool result = false;
            bool loop = true;
            Console.WriteLine(query);
            while(loop)
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

        /*
         * Refactor - more than one recipe can have same name
         * allow to select single recipe from ones with same name
         */
        public bool DeleteRecipe(string name)
        {
            bool remove = false;
            if (recipes.Any())
            {
                Recipe recipeToRemove = FindSingle(name);
                if (recipeToRemove != null)
                {
                    remove = Confirm("Are you sure you want to delete " + name + "? [Y/N]");
                    if (remove)
                    {
                        recipes.Remove(recipeToRemove);
                    }
                }
            }
            return remove;
        }
        public void EditRecipe(string name)
        {
            if (recipes.Any())
            {
                Recipe recipeToEdit = FindSingle(name);
                if (recipeToEdit != null)
                {
                    Console.WriteLine("New name for recipe: ");
                    string newName = ""; 
                    newName = Console.ReadLine();
                    recipeToEdit.Name = newName;
                }
            }
        }
        public void ShowRecipe(string name)
        {
            if (recipes.Any())
            {
                
            }
        }
        public void RateRecipe(Recipe recipe, int rating)
        {
            (int, int) oldRating = recipe.Rating;
            recipe.Rating = (oldRating.Item1 + rating, oldRating.Item2 + 1);
        }
        public void ListRecipes()
        {
            if (recipes.Any())
            {
                int counter = 1;
                foreach(Recipe recipe in recipes)
                {
                    Console.Write(counter + ":\t" + recipe.Name + "\n");
                    counter++;
                }
            }
        }

        public void ListRecipes(string name)
        {
            if (recipes.Any())
            {
                int counter = 1;
                List<Recipe> foundRecipes = recipes.FindAll(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                foreach (Recipe recipe in foundRecipes)
                {
                    Console.Write(counter + ":\t" + recipe.Name + "\n");
                    counter++;
                }
            }
        }

        public int AmountOfRecipes() {
            if (recipes.Any())
            {
                return recipes.Count;
            }
            return 0;
        }
    }
}
