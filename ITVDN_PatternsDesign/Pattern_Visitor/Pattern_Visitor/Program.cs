using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Village village = new Village();
            village.Add(new BoysHouse());
            village.Add(new GirlsHouse());

            village.Accept(new Santa());
            village.Accept(new Trolle());

            Console.ReadKey();
        }
    }
}
