using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CodeFirstDB>());
            using (CodeFirstDB db = new CodeFirstDB())
            {
                Product p1 = new Product { Name = "Cola", Price = 10 };
                Product p2 = new Product { Name = "Fanta", Price = 12 };
                Product p3 = new Product { Name = "Sprite", Price = 11 };

                db.MyProducts.AddRange(new List<Product> { p1, p2, p3 });
                db.SaveChanges();

                Customer customer1 = new Customer { Name = "Alex" };
                Customer customer2 = new Customer { Name = "Brad" };

                db.MyCustomers.AddRange(new List<Customer> { customer1, customer2 });
                db.SaveChanges();

                Order order1 = new Order
                {
                    Customer = customer1, Products = new List<Product> { p1, p2 }
                };
                Order order2 = new Order
                {
                    Customer = customer2,
                    Products = new List<Product> { p3, p2 }
                };

                db.MyOrders.AddRange(new List<Order> { order1, order2 });
                db.SaveChanges();
            }

        }
    }
}
