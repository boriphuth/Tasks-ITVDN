using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_Command_Calculator
{
    class ControlUnit
    {
        List<Command> commands = new List<Command>();
        int current = 0;

        public void ExecuteCommand()
        {
            commands[current].Execute();
            ++current;
        }

        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (current > 0)
                    commands[--current].UnExecute();
        }

        public void StoreCommand(Command command)
        {
            commands.Add(command);
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
                if (current < commands.Count - 1)
                    commands[current++].Execute();
        }
    }
}
