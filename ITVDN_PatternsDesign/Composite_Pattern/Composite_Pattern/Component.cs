using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{
    abstract class Component
    {
        public string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract Component GetChild(int index);
        public abstract void Operation();
        public abstract void Remove(Component c);

    }
}
