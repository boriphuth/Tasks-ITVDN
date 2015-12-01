using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ITVDN_EF6_Task5_Part2.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(o => o.Id);
            Property(o => o.Date).IsOptional().HasColumnName("Created").HasColumnType("datetime2");

        }
    }
}
