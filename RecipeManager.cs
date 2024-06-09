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
    class RecipeManager
    {
        private Dictionary<string, Recipe> recipes;

        public RecipeManager()
        {
            recipes = new Dictionary<string, Recipe>();
        }

        public bool AddRecipe(Recipe recipe)
        {
            if (recipes.ContainsKey(recipe.Name))
                return false; 
            recipes.Add(recipe.Name, recipe);
            return recipes.ContainsKey(recipe.Name);
        }

        public bool DeleteRecipe(string name)
        {
            return recipes.Remove(name);
        }
 
        public void EditRecipe(Recipe recipe, string name)
        {
            Recipe modifiedRecipe = new Recipe(recipe);
            modifiedRecipe.Name = name;
            AddRecipe(modifiedRecipe);
            DeleteRecipe(recipe.Name);
        }

        public bool RecipeExists(string name)
        {
            return recipes.ContainsKey(name);
        }

        public Recipe SelectRecipe(string name)
        {
            Recipe recipe;
            recipes.TryGetValue(name, out recipe);
            return recipe;
        }

        public Recipe SelectRecipe(int index)
        {
            if(recipes.Any() && index < recipes.Count)
                return recipes.ElementAt(index).Value;
            return null;
        }

        public string ShowRecipe(string name)
        {
            Recipe recipe = SelectRecipe(name);
            return recipe.ToString();
        }

        public int AmountOfRecipes() {
            if (recipes.Any())
            {
                return recipes.Count;
            }
            return 0;
        }

        public List<string> TableOfContents()
        {
            List<string> names = new List<string>();
            foreach (KeyValuePair<string,Recipe> element in recipes)
            {
                names.Add(element.Key);
            }
            return names;
        }
    }
}
