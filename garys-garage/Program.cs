using System;

namespace garys_garage
{
    class Program
    {
        static void Main(string[] args)
        {
            Ram dodgeRam = new Ram() { MainColor = "Red" };
            Cessna mx410 = new Cessna() { MainColor = "White" };
            Tesla model3 = new Tesla() { MainColor = "Silver" };
            dodgeRam.Drive();
            mx410.Drive();
            model3.Drive();

        }
    }
}
