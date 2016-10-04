using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Bajoren,
            Vulcan,
            Betazoid
        }

        public enum Section
        {
            None,
            Engineering,
            Medical,
            Bridge,
            Security
        }

        public enum Gender
        {
            None,
            Male,
            Female
        }
        #endregion

        #region FIELDS
        private string _firstName;
        private string _lastName;
        private string _rank;
        private Section _section;
        private RaceType _race;
        private string _shipLocation;
        private int _age;
        private Gender _gender;
        private RaceType race;

        public string ShipLocation
        {
            get { return _shipLocation; }
            set { _shipLocation = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Rank
        {
            get { return _rank; }
            set { _rank = "Ensign"; }
        }

        public Gender gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public Section section
        {
            get { return _section; }
            set { _section = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        #endregion


        #region PROPERTIES


        #endregion


        #region CONSTRUCTORS
        public Character()
        {

        }
        //public Character(string firstName, string lastName, RaceType race, string shipLocation, string rank, int age, Gender gender, Section section)
        //{
        //    _firstName = firstName;
        //    _lastName = lastName;
        //    _race = race;
        //    _gender = gender;
        //    _age = age;
        //    _rank = rank;
        //    _shipLocation = shipLocation;
        //}

        public Character(string firstName, string lastName, Gender gender, RaceType race, string shipLocation, int age, Section section, string rank)
        {
            FirstName = firstName;
            LastName = lastName;
            this.gender = gender;
            this.race = race;
            ShipLocation = shipLocation;
            Age = age;
            this.section = section;
            Rank = rank;
        }

        #endregion


        #region METHODS



        #endregion




    }
}
