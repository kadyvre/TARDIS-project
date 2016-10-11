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
            ShipLocation spt = null;

            foreach (ShipLocation location in ShipLocations)
            {
                if (location.ShipLocationID == ID)
                {
                    spt = location;
                    break;
                }
                if (spt == null)
                {
                    string feedbackMessage = ($"The Ship Section {ID} you have entered does not exist," + Environment.NewLine +
                    "Please enter a valid ID");
                }
            }

            return spt;
        }
    }
}

