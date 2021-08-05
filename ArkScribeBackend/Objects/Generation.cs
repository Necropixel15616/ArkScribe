using System;
using System.Collections.Generic;
using System.Text;

namespace ArkScribeBackend.Objects
{
    public class Generation
    {
        public int Mutations { get; set; }
        public int Level
        {
            get
            {
                return 1 + Health + Stamina + Oxygen + Food + Weight + Melee + Speed;
            }
            set { }
        }
        public int Health { get; set; }
        public int Stamina { get; set; }
        public int Oxygen { get; set; }
        public int Food { get; set; }
        public int Weight { get; set; }
        public int Melee { get; set; }
        public int Speed { get; set; }
    }
}
