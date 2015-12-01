using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVDN_EF6_Task5_Part2
{
    public static class OperationsAsync
    {
        public static async Task SetOrdersAsync(List<string> names)
        {
            using (var db = new EF6_PhoneStoreDB())
            {
                db.Orders.AddRange(
                new List<Order>
                {
                    new Order
                    {
                        Customer = names[0],
                        Date = DateTime.Now,
                        Phones = (from p in db.Phones
                                  where p.Id == 1 || p.Id == 2
                                  select p).ToList()
                    },
                    new Order
                    {
                        Customer = names[1],
                        Date = DateTime.Now,
                        Phones = (from p in db.Phones
                                  where p.Id == 3 || p.Id == 4
                                  select p).ToList()
                    }
                });
                await db.SaveChangesAsync();
            }
        }

        public static async Task GetOrderAsync()
        {
            using (var db = new EF6_PhoneStoreDB())
            {
                await db.Orders.ForEachAsync(p =>
                {
                    Console.WriteLine("{0} {1}", p.Customer, p.Date);
                    foreach (var item in db.Phones)
                    {
                        if (item.OrderId == p.Id)
                        {
                            Console.WriteLine("     {0} {1}", item.Company, item.Model);
                        }
                        
                    }
                }
                );
            }
        }
    }
}
