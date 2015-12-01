using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ITVDN_EF6_Task5
{
    class DBInitializer : DropCreateDatabaseAlways<PhonesDb>
    {
        protected override void Seed(PhonesDb context)
        {
            Phone ph1 = new Phone { Company = "Nokia", Model = "Lumia 930" };
            Phone ph2 = new Phone { Company = "Vertu", Model = "Ferrary" };
            context.Phones.Add(ph1);
            context.Phones.Add(ph2);
            context.SaveChanges();
        }
    }
}
