using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator
{
    class Propeller : Decorator
    {
        public override void Operation()
        {
            Component.Operation();
            propeller = "propeller";
            Fly();
        }

        void Fly()
        {
            Console.WriteLine("I have a {0} and I can fly", propeller);
        }
        string propeller;

       
    }
}
