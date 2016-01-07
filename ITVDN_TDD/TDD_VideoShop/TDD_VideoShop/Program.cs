using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_VideoShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Jack Daniels");
            customer.Rental.Add(new Rental(new Movie("Aliens", 5),7));
            customer.Rental.Add(new Rental(new Movie("Born", 2), 7));

            Console.WriteLine("Total: {0:C}",customer.CalculateTotal());

            ReportManager.CreateReport("Report.txt", customer);
            Console.ReadKey();
        }
    }
}
