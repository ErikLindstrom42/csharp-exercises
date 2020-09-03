using System;

namespace garys_garage {
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

                public override void Stop() {
            Console.WriteLine($"The {MainColor} Tesla smoothly stops thanks to ABS.");
        }

        public override void Turn() {
            Console.WriteLine($"The {MainColor} zips through a turn at high speed.");
        }
    }
}