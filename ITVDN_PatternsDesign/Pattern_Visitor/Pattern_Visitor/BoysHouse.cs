using System;

namespace Pattern_Visitor
{
    public class BoysHouse : House
    {
        public override void Accept(Visitor visitor)
        {
            if (CheckTrolle(visitor))
            {
                Console.WriteLine("Trolle don't entry in BoysHouse!");
                return;
            }
            visitor.VisitBoysHouse(this);
        }

        private bool CheckTrolle(Visitor visitor)
        {
            return visitor is Trolle;
        }

        public void GiveBall()
        {
            Console.WriteLine("Ball as a gift.");
        }
    }
}