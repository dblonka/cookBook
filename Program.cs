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
    class Program
    {
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
