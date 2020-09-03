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
        public virtual void Stop()
        {
            Console.WriteLine("Screeeech");
        }

        public virtual void Turn()
        {
            Console.Write("Zoooom");
        }
    }



}