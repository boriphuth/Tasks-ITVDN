using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Context
    {
        public Context(State state)
        {
            State = state;
        }

        public State State { get; set; }

        public void Request()
        {
            State.Handle(this);
        }
    }
}
