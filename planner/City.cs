using System;
using System.Collections.Generic;

namespace Planner
{
    public class City
    {
        public string Name { get; set; }
        public string Mayor { get; set; }
        public string YearEstablished { get; set; }

        private Dictionary<string, Building> Architecture { get; set; }
        
    }
}