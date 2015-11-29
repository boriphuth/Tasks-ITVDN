namespace ITVDN_EF6_Task3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EF6_Task3DB : DbContext
    {
        // Your context has been configured to use a 'EF6_Task3DB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ITVDN_EF6_Task3.EF6_Task3DB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EF6_Task3DB' 
        // connection string in the application configuration file.
        public EF6_Task3DB()
            : base("name=EF6_Task3DB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}