using System;

namespace Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            Building Kroger = new Building("123 Main St.");
            Kroger.Width = 10;
            Kroger.Depth = 10;
            Kroger.Stories = 3;
            Kroger.Purchase("Tim");
            Kroger.Construct();

            Building Dennys = new Building("29 Arlington Ave.");
            Dennys.Width = 15;
            Dennys.Depth = 15;
            Dennys.Stories = 5;
            Dennys.Purchase("Douglas Adams");
            Dennys.Construct();

            Building IHOP = new Building("32 W 54th St.");
            IHOP.Width = 8;
            IHOP.Depth = 10;
            IHOP.Stories = 1;
            IHOP.Purchase("Tom Bombadill");
            IHOP.Construct();

            Building PPYC = new Building("32 W 54th St.") {
            Width = 8,
            Depth = 10,
            Stories = 1
            };
            PPYC.Purchase("Tom Bombadill");
            PPYC.Construct();
            Dennys.ShowBuilding();
            Kroger.ShowBuilding();
            IHOP.ShowBuilding();

        }


    }
}
