using FileManagementSystem.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementSystem
{
    class Program
    {
        static void Main()
        {
            var listener = new Listener(@"C:\Users\Дмитрий\Desktop\T");
            listener.Start();
        }
    }
}
