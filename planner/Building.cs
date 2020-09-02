using System;
using System.Collections.Generic;

namespace Planner
{
    public class Building
    {
        private string _designer { get; set; }
        private DateTime _dateConstructed { get; set; }
        private string _address { get; set; }
        private string _owner { get; set; }

        public int Stories { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public double Volume
        {
            get
            {
                return Stories * Width * Depth * 3;
            }
        }

        public void Construct()
        {
            _dateConstructed = DateTime.Now;
        }

        public void Purchase(string buyer)
        {
            _owner = buyer;
        }
        public Building(string address)
        {
            _address = address;

        }

        public void ShowBuilding()
        {
            Console.WriteLine(_address);
            Console.WriteLine("--------------");
            Console.WriteLine($"Designed by {_designer}");
            Console.WriteLine($"Constructed on {_dateConstructed}");
            Console.WriteLine($"Owned by {_owner}");
            Console.WriteLine($"{Volume} cubic meters of space");
        }


    }
}