using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5_Part2
{
    public class MyDBInitializer : DropCreateDatabaseAlways<EF6_PhoneStoreDB>
    {
        protected override void Seed(EF6_PhoneStoreDB context)
        {
            Phone ph1 = new Phone { Company = "Nokia", Model = "Lumia 930" };
            Phone ph2 = new Phone { Company = "Vertu", Model = "Ferrary" };
            Phone ph3 = new Phone { Company = "Lenovo", Model = "N93" };
            Phone ph4 = new Phone { Company = "Samsung", Model = "S4" };
            context.Phones.AddRange(new List<Phone> { ph1, ph2, ph3, ph4 });
            context.SaveChanges();
        }
    }
}
