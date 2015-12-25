using System;

namespace StatePattern
{
    internal class ConcreateStateB : State
    {        

        public override void Handle(Context context)
        {
            context.State = new ConcreateStateA();
            Console.WriteLine("Change on A");
        }
    }
}