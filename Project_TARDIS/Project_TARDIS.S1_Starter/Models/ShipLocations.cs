using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class ShipLocation
    {
        #region FIELDS

        private string _name;
        private string _description;
        private int _shipLocationID;
        private bool _accesssable;

        #endregion


        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int ShipLocationID
        {
            get { return _shipLocationID; }
            set { _shipLocationID = value; }
        }

        public bool Accessable
        {
            get { return _accesssable; }
            set { _accesssable = value; }
        }
        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
