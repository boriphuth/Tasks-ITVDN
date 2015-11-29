using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EF6_Task3DB>());
            using (EF6_Task3DB db = new EF6_Task3DB())
            {
                Product p1 = new Product { Name = "Cola", Price = 10 };
                Product p2 = new Product { Name = "Fanta", Price = 12 };
                Product p3 = new Product { Name = "Sprite", Price = 11 };
                Product p4 = new Product { Name = "Sprite", Price = 100 };

                db.Products.AddRange(new List<Product> { p1, p2, p3,p4 });
                db.SaveChanges();

                Person person1 = new Person { Name = "Fred", Products = new List<Product> { p1 } };
                Person person2 = new Person { Name = "Nick", Products = new List<Product> { p3, p2 } };
                Person person3 = new Person { Name = "Lena", Products = new List<Product> { p4 } };

                db.Persons.AddRange(new List<Person> { person1, person2 , person3 });
                db.SaveChanges();

                Console.WriteLine("connected complete...");
                Console.ReadKey();

                var first = db.Persons.FirstOrDefault(o => o.Name == "Nick");

                Console.WriteLine(first != null ? first.Name : "null");
                if (first != null)
                {
                    foreach (var item in first.Products)
                    {
                        Console.WriteLine(item.Name + " -> " + item.Price);
                    }
                }

                Console.ReadKey();

                //-----------------------------------------------------------------
                var min = from pers in db.Persons
                            //.Include("Products")
                            select new { Name = pers.Name, Min = pers.Products.Min(o => o.Price) };
                Console.WriteLine(min);
                foreach (var item in min)
                {
                    Console.WriteLine(item.Name + " has min " + item.Min + " products price");
                }

                Console.ReadKey();
            }
        }
    }
}
