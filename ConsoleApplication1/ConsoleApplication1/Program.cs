using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string myText = "678";
            int myInt;
            bool isInt;

            isInt = int.TryParse(myText, out myInt);

            Console.WriteLine($"Integer: \"{myInt}\"");
            Console.WriteLine($"Is Integer {isInt}");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
