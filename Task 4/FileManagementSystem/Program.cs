using FileManagementSystem.Logic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    class Program
    {
        static void Main()
        {
            var consoleMenu = new ConsoleMenu();
            consoleMenu.Start();
        }
    }
}
