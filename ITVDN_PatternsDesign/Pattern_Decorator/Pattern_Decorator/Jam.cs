using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator
{
    class Jam : Decorator
    {
        string jam;

        public override void Operation()
        {
            base.Operation();
            this.jam = "jam";
            Console.WriteLine("I have {0}",jam);
        }
    }
}
