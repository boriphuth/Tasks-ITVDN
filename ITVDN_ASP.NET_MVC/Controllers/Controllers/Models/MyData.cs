using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Controllers.Models
{
    public class MyData : IEnumerable
    {
        List<Product> products;
        public MyData()
        {
            products = new List<Product>();
            products.Add(new Product() { Name = "Orange", Price = 5 });
            products.Add(new Product() { Name = "Lemon", Price = 7 });
        }

        public IEnumerable<Product> GetData()
        {
            return products;
        }
        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}