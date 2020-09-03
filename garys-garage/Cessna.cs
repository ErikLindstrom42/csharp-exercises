using System;
namespace garys_garage
{

    public class Cessna : Vehicle, IGasVehicle
    {
        public double FuelCapacity { get; set; }
        public int CurrentTankPercentage { get; set; }

        public void RefuelTank()
        {
            CurrentTankPercentage = 100;
        }

        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Cessna flies by: Zoooooom!");
        }

        public override void Stop()
        {
            Console.WriteLine($"The {MainColor} Cessna rolls to a stop after rolling a mile down the runway.");
        }

        public override void Turn()
        {
            Console.WriteLine($"The {MainColor} Cessna carefully rolls through a turn.");
        }
    }
}