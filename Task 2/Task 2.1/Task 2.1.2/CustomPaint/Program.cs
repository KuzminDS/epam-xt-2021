using CustomPaint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();

            var painter = new Painter(userService);
            var consolePainter = new ConsolePainter(painter);

            consolePainter.Start();
        }
    }
}
