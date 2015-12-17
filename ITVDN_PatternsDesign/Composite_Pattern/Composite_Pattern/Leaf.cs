using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    class Leaf : Component
    {
        public Leaf(string name)
            :base(name)
        {
        }

        public override void Add(Component c)
        {
            throw new Exception();
        }

        public override Component GetChild(int index)
        {
            throw new Exception();
        }

        public override void Operation()
        {
            Console.WriteLine(base.name);
        }

        public override void Remove(Component c)
        {
            throw new Exception();
        }
    }
}
