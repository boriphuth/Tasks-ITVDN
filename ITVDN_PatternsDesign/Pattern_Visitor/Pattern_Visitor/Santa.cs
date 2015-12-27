using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    class Santa : Visitor
    {
        public override void VisitBoysHouse(BoysHouse boysHouse)
        {
            boysHouse.GiveBall();
        }

        public override void VisitGirlsHouse(GirlsHouse girlsHouse)
        {
            girlsHouse.TellFairyTale();
        }
    }
}
