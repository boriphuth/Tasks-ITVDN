using System;

namespace TDD_VideoShop
{
    public class Rental
    {
        private int days;
        private Movie movie;


        public Rental(Movie movie, int days)
        {
           
            this.Movie = movie;
            this.Days = days;
        }

        public Movie Movie
        {
            get
            {
                return movie;
            }

            set
            {
                movie = value;
            }
        }

        public int Days
        {
            get { return days; }     
            set
            {
                if (value < 0)
                {
                    throw new DaysExeptions(value);
                }                
                days = value;
            }
        }

        public double CalculateDebt()
        {
            return Movie.RentalPrice * days;
        }
    }
}