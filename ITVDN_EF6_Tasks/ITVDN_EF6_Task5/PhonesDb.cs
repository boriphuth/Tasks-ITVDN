namespace ITVDN_EF6_Task5
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonesDb : DbContext
    {
        
        static PhonesDb()
        {
            Database.SetInitializer(new DBInitializer());
        }

        public PhonesDb()
            : base("name=PhonesDb")
        {

        }

       

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<SmartPhone> SmartPhones { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }

}