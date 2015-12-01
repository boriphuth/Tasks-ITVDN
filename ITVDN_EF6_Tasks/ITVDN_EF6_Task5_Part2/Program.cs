using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EF6_PhoneStoreDB())
            {
                Task task = OperationsAsync.SetOrdersAsync(new List<string> { "Nick", "Fred" });
                task.Wait();

                task = OperationsAsync.GetOrderAsync();
                task.Wait();
                Console.ReadKey();
            }
        }
    }
}
