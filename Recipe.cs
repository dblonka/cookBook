using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace cookBook
{
    internal class Recipe
    {
        private string _name = "";
        private int _servings = 0;
        private int _difficulty = 0;
        private int _prepTime = 0;
        private (int,int) _rating = (0,0);
        private Dictionary<string, int> _ingredients;
        private string _descritpion = "";

        public string Name { get { return _name; } set { _name = value; } }
        public int Servings { get { return _servings; } set { _servings = value; } }
        public int Difficulty { get { return _difficulty; } set { _difficulty = value; } }
        public int PrepTime { get { return _prepTime; } set { _prepTime = value; } }
        public (int,int) Rating { get { return _rating; } set { _rating = value; } }
        public Dictionary<string, int> Ingredients { get { return _ingredients; } set { _ingredients = value; } }
        public string Descritpion { get { return _descritpion; } set { _descritpion = value; } }
        
        public Recipe() { }
        public Recipe(string name, int servings, int difficulty, int prepTime, Dictionary<string, int> ingredients, string descritpion)
        {
            Name = name;
            Servings = servings;
            Difficulty = difficulty;
            PrepTime = prepTime;
            Descritpion = descritpion;
            Ingredients = ingredients;
        }

        public Recipe(string name, string descritpion)
        {
            Name = name;
            Descritpion = descritpion;
        }

    }
}
