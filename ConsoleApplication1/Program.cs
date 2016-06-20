using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookCore;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console customization
            Console.Title = "Phone Book";
            Console.CursorVisible = false;

            // Set window params
            Console.WindowHeight = 40;
            Console.WindowWidth = 100;

            var app=new PhoneBookEngine();
            app.StartApp();
        }
    }
}
