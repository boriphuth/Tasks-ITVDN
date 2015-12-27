using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    public class Trolle : Visitor
    {
        public override void VisitBoysHouse(BoysHouse boysHouse)
        {
            Console.WriteLine("Give nothing...");
        }

        public override void VisitGirlsHouse(GirlsHouse boysHouse)
        {
            Console.WriteLine("Give nothing...");
        }
    }
}
