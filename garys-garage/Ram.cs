using System;

namespace garys_garage
{
    
    public class Ram : Vehicle
    {
        public double FuelCapacity { get; set; }

        public void RefuelTank()
        {
            //omitted
        }
        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Ram rolls by: Rrruuummmble!");
        }
        public override void Stop() {
            Console.WriteLine($"The {MainColor} Ram skids to a stop in the dirt.");
        }

        public override void Turn() {
            Console.WriteLine($"The {MainColor} Ram flips while trying to turn.");
        }

    }
}