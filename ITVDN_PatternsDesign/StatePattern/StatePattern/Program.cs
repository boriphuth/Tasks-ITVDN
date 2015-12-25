using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new ConcreateStateA());

            for (int i = 0; i < 10 ; i++)
            {
                context.Request();
            }

            Console.ReadKey();
        }
    }
}
