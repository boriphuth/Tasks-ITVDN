using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using ITVDN_EF6_Task5_Part2.Configuration;

namespace ITVDN_EF6_Task5_Part2
{


    public class EF6_PhoneStoreDB : DbContext
    {
        // Your context has been configured to use a 'EF6_PhoneStoreDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ITVDN_EF6_Task5_Part2.EF6_PhoneStoreDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EF6_PhoneStoreDB' 
        // connection string in the application configuration file.
        static EF6_PhoneStoreDB()
        {
            Database.SetInitializer(new MyDBInitializer());
        }
        public EF6_PhoneStoreDB()
            : base("name=EF6_PhoneStoreDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PhoneConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}