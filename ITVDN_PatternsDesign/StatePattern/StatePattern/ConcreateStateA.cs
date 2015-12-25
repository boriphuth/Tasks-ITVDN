using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class ConcreateStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreateStateB();
            Console.WriteLine("Change on B");
        }
    }
}
