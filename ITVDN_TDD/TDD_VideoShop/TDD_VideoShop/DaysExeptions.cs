using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_VideoShop
{
    public class DaysExeptions : Exception
    {
        public object Days { get; set; }
        public DaysExeptions(int days)
        {
            Days = days;
        }
    }
}
