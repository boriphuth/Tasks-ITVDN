using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    public abstract class Visitor
    {
        public abstract void VisitBoysHouse(BoysHouse boysHouse);
        public abstract void VisitGirlsHouse(GirlsHouse boysHouse);

    }
}
