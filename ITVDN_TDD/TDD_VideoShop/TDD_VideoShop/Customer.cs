using System;
using System.Collections.Generic;

namespace TDD_VideoShop
{
    public class Customer
    {
        private string name;
        List<Rental> rental;

        public Customer(string name)
        {
            this.Name = name;
            rental = new List<Rental>();
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public List<Rental> Rental { get { return rental; } set { rental = value; } }
       

        //public void Add(Movie movie, int days)
        //{
        //    rental.Add(new Rental(movie, days));
        //}

        public double CalculateTotal()
        {
            double totalAmount = 0;

            foreach (Rental item in Rental)
            {
                totalAmount += item.CalculateDebt();
            }

            return totalAmount;
        }
    }
}