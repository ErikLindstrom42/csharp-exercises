using System;

namespace garys_garage
{

    public class Vehicle
    {
        public string MainColor { get; set; }
        public string MaximumOccupancy { get; set; }

        public virtual void Drive()
        {
            Console.WriteLine("Vrooom!");
        }
    }

    public class Cessna : Vehicle
    {
        public double FuelCapacity { get; set; }

        public void RefuelTank()
        {
            // method definition omitted
        }

        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Cessna flies by: Zoooooom!");
        }
    }

    public class Tesla : Vehicle
    {
        public double BatteryKWh { get; set;}
        public void ChargeBattery()
        {
            //omitted
        }
        public override void Drive()
        {
            Console.WriteLine($"The {MainColor} Tesla drives by: Whhiiirrrr!");
        }
    }

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
    }
}