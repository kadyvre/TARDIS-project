using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Universe
    {

        public List<ShipLocation> ShipLocations { get; set; }

        public Universe()
        {
            ShipLocations = new List<ShipLocation>();
        }
        public ShipLocation GetShipLocationByID(int ID)
        {
            ShipLocation spt = new ShipLocation();



            return spt;
        }
    }
}

