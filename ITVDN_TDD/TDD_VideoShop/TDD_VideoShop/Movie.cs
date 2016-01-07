namespace TDD_VideoShop
{
    public class Movie
    {
        private double rentalPrice;
        private string name;

        public double RentalPrice
        {
            get
            {
                return rentalPrice;
            }
            
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

        public Movie(string name, double rentalPrice)
        {
            this.Name = name;
            this.rentalPrice = rentalPrice;
        }
    }
}