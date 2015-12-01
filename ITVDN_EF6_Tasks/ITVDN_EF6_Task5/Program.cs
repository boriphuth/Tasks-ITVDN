using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            using ( PhonesDb db = new PhonesDb() )
            {
                db.SmartPhones.Add(new SmartPhone
                {
                    Company = "SonyErricson",
                    Model = "S600",
                    OS = "Windows 10"
                });
                db.SaveChanges();
                //TODO:
                foreach (SmartPhone item in db.SmartPhones)
                {
                    Console.WriteLine("{0} {1} {2} {3}",item.Company,item.Model,item.OS,item.Processor);
                }
                Console.WriteLine(new string('-',30));
                foreach (Phone item in db.Phones)
                {
                    Console.WriteLine("{0} {1}", item.Company, item.Model);
                }
                Console.ReadKey();
            }
        }
    }
}
