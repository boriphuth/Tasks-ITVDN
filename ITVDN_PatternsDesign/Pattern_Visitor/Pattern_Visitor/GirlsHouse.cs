using System;

namespace Pattern_Visitor
{
    public class GirlsHouse : House
    {
        public override void Accept(Visitor visitor)
        {
            if (CheckTrolle(visitor))
            {
                Console.WriteLine("Trolle don't entry in GirlsHouse!");
                return;
            }
            visitor.VisitGirlsHouse(this);
        }

        private static bool CheckTrolle(Visitor visitor)
        {
            return visitor is Trolle;
        }

        public void TellFairyTale()
        {
            Console.WriteLine("Fairy Tale...");
        }
    }
}