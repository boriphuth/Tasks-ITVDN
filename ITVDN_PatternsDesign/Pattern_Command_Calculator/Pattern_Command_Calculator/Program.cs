using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            int result = 0;

            result = calculator.Add(5);
            Console.WriteLine(result);

            result = calculator.Sub(3);
            Console.WriteLine(result);

            result = calculator.Undo(2);
            Console.WriteLine(result);

            result = calculator.Redo(1);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
