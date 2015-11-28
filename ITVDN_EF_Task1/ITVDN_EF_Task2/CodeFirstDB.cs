namespace ITVDN_EF_Task2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeFirstDB : DbContext
    {
        // Your context has been configured to use a 'CodeFirstDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ITVDN_EF_Task2.CodeFirstDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodeFirstDB' 
        // connection string in the application configuration file.
        public CodeFirstDB()
            : base("name=CodeFirstDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> MyProducts { get; set; }
        public virtual DbSet<Order> MyOrders { get; set; }
        public virtual DbSet<Customer> MyCustomers{ get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}