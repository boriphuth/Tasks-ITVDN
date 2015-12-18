using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator
{
    class Trousers : Decorator
    {
        public override void Operation()
        {
            Component.Operation();
            thing = "trousers";
            Console.WriteLine("I have a {0}",thing);
        }

        string thing;

        
    }
}
