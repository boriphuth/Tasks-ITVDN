using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Visitor
{
    class Village
    {
        ArrayList houses = new ArrayList();

        public void Add(House house)
        {
            houses.Add(house);
        }

        public void Remove(House house)
        {
            houses.Remove(house);
        }

        public void Accept(Visitor visitor)
        {
            foreach (House house in houses)
            {
                house.Accept(visitor);
            }
        }
    }
}
