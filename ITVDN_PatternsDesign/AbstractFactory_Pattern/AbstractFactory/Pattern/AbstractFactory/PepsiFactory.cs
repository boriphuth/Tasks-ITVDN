using System;

namespace AbstractFactory
{
    class PepsiFactory : AbstractFactory
    {
        public override AbstractWater CreateWater()
        {
            return new PepsiWater();
        }

        public override AbstractBottle CreateBottle()
        {
            return new PepsiBottle();
        }

        public override AbstractCover CreateCover()
        {
            return new PepsiCover();
        }
    }
}
