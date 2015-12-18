using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    class ShwapesFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new ShwapesBottle();
        }

        public override AbstractWater CreateWater()
        {
            return new ShwapesWater();
        }

        public override AbstractCover CreateCover()
        {
            return new ShwapesCover();
        }
    }
}
