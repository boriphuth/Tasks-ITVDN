using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Report
    {
        public Guid PatientID { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string VisitDoctorName { get; set; }
        public string Diagnosise { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
