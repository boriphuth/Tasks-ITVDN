using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    class Composite : Component
    {
        public Composite(string name)
            :base(name)
        {
            children = new ArrayList();
        }

        ArrayList children;
        public override void Add(Component c)
        {
            children.Add(c);
        }

        public override Component GetChild(int index)
        {
            return children[index] as Component;
        }

        public override void Operation()
        {
            Console.WriteLine(base.name);
            foreach (Component item in children)
            {
                item.Operation();
            }
        }

        public override void Remove(Component c)
        {
            children.Remove(c);
        }
    }
}
