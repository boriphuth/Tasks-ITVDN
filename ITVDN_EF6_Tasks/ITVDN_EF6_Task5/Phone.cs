using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
    }
}
