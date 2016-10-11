using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Player : Character
    {
        #region FIELDS



        #endregion


        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public Player()
        {

        }

        public Player(string firstName, string lastName, int age, string rank, RaceType race, GenderType gender, SectionType section, int shipLocation ) :base(firstName, lastName, gender, race, shipLocation, age, section, rank)
        {

        }             
        #endregion



        #region METHODS



        #endregion
    }
}
