using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cookBook
{
    internal class Program
    {

        //static List <Recipe> recipes = new List<Recipe>();
        static InputOutput control = new InputOutput();
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                running = control.MainMenu();
            }
        }
    }
}
