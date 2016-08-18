using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string color = "red";
            var x = color.In<string>("green", "yellow", "bluw", "red");
            var y = color.In("green", "yellow", "bluw", "redd");
            var z = color.Pos("green", "yellow", "bluw", "red");

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            int tt = 10;
            x = tt.In<int>(12,34,454,6767,10);
            y = tt.In(12, 34, 454,6767,101);
            z = tt.Pos(12, 34, 454, 6767,10);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            Console.ReadLine();
        }
    }
}
