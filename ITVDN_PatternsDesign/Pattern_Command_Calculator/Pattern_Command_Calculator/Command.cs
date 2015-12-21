using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command_Calculator
{
    abstract class Command
    {
        protected int operand;
        protected ArithmeticUnit unit;

        public abstract void Execute();
        public abstract void UnExecute();
    }
}
