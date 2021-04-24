using FileManagementSystem.Logic;
using System;
using System.Collections.Generic;
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
            //var listener = new Listener(@"C:\Users\Дмитрий\Desktop\T");
            //listener.Start();
            //Thread.Sleep(TimeSpan.FromSeconds(50));
            //listener.End();

            string str = @"22.04.2021 21-45-33".Replace('-', ':');
            var dateTime = DateTime.Parse(str);
            //Console.WriteLine(dateTime);

            var rollbackService = new RollbackService(@"C:\Users\Дмитрий\Desktop\T");
            rollbackService.Rollback(dateTime);
        }
    }
}
