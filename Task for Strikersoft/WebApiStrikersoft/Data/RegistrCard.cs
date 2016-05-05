using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RegistrCard
    {
        public Guid ID { get; set; }
        public Guid PatientID { get; set; }
        public Guid DoctorID { get; set; }
        public string Diagnosise { get; set; }
        public DateTime VisitDate { get; set; }

   
    }
}
