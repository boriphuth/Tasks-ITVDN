using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ModelDBTask3>());
            using (ModelDBTask3 db = new ModelDBTask3())
            {
                Product p1 = new Product { Name = "Cola", Price = 10 } ;
                Product p2 = new Product { Name = "Fanta", Price = 12 };
                Product p3 = new Product { Name = "Sprite", Price = 11 };

                db.Products.AddRange(new List<Product> { p1, p2, p3 });
                db.SaveChanges();

                Person person1 = new Person { Name = "Fred", Products = new List<Product> { p1 } };
                Person person2 = new Person { Name = "Nick", Products = new List<Product> { p3 } };
                Person person3 = new Person { Name = "Lena", Products = new List<Product> { p2 } };

                db.Persons.AddRange(new List<Person> { person1, person2, person3 });
                db.SaveChanges();

                Console.WriteLine("connected complete...");
                Console.ReadKey();
                //---------------------------------------------------------
                

                var ordBy = from pers in db.Persons
                            orderby pers.Name
                            select pers;

                foreach (var item in ordBy)
                {
                    Console.WriteLine(ordBy != null ? item.Name : "null");
                }

                Console.ReadKey();
                //-----------------------------------------------------------------
                var count = from pers in db.Persons
                          
                          select new { Name = pers.Name, Count = pers.Products.Count() };
                foreach (var item in count)
                {
                    Console.WriteLine(item.Name + " has " + item.Count + "products");
                }

                Console.ReadKey();

            }
        }
    }
}
