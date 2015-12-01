using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5_Part2
{
    public class Order
    {
        public Order()
        {
            Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime? Date { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
