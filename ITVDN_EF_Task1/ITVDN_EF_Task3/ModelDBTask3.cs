namespace ITVDN_EF_Task3
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelDBTask3 : DbContext
    {
        // Your context has been configured to use a 'ModelDBTask3' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ITVDN_EF_Task3.ModelDBTask3' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelDBTask3' 
        // connection string in the application configuration file.
        public ModelDBTask3()
            : base("name=ModelDBTask3")
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