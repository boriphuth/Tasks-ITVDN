using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Decorator
{
    abstract class Decorator : Component
    {
        public Component Component { protected get; set; }
        public override void Operation()
        {
            if (Component != null)
                Component.Operation();
        }
    }
}
