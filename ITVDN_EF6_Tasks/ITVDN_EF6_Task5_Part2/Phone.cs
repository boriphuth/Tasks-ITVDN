using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5_Part2
{
    public class Phone
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        // only nulable
        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
