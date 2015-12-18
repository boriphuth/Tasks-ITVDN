using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Component carlson = new Carlson();
            Decorator trousers = new Trousers();
            Decorator propeller = new Propeller();
            Decorator jam = new Jam();

            trousers.Component = carlson;
            jam.Component = trousers;
            propeller.Component = jam;

            
            
            propeller.Operation();

            Console.ReadKey();
        }
    }
}
