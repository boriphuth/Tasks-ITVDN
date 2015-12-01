using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5
{
    public class SmartPhone : Phone
    {
        public string OS { get; set; }
        public string Processor { get; set; }
    }
}
