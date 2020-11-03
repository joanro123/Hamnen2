using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen2
{
    class Hamnen
    {
        
        
        public double Storlek { get; set; }
        
        public List<Slot> Båtplatser { get; set; }      

    }

    class Slot
    {
        public double SlotSize { get; set; }
        public string ID { get; set; }
        public bool Reserverad { get; set; }


    }
}

