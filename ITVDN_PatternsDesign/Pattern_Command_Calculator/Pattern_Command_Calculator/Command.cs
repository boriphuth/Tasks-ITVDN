using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command_Calculator
{
    abstract class Command
    {
        int operand;
        ArithmeticUnit unit;
        public abstract int Execute();
        public abstract int UnExecute();
    }
}
