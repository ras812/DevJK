using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;

namespace TypesInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start program
            // try
            var menu = new MainMenu(); //переменная как класс
            //MainMenu menu = new MainMenu();
            menu.StartMainMenu();
            // catch
            // End program
        }
    }
}

