using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    public class Controller
    {
        #region FIELDS
        

        private bool _usingGame;
        bool _missionInitialized = false;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //
        private ConsoleView _gameConsoleView;
        private Player _gamePlayer;
        private Universe _gameUniverse;

        #endregion

        #region PROPERTIES


        #endregion


        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();

            //
            // begins running the application UI
            //

            ManageGameLoop();
        }

        #endregion


        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {

            //
            // instantiate a player and universe object
            //

            _gamePlayer = new Player();
            _gameUniverse = new Universe();

            //
            // instantiate a ConsoleView object
            //

            _gameConsoleView = new ConsoleView(_gamePlayer, _gameUniverse);

            InitializeUniverse();
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            PlayerAction playerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            _usingGame = true;
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                playerActionChoice = _gameConsoleView.DisplayGetPlayerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (playerActionChoice)
                {
                    case PlayerAction.None:
                        break;
                    case PlayerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case PlayerAction.Move:
                        _gamePlayer.ShipLocation = _gameConsoleView.DisplayGetPlayersNewDestination().ShipLocationID;
                        break;
                    case PlayerAction.ListShipAreas:
                        _gameConsoleView.DisplayListAllShipSections();
                        break;
                    case PlayerAction.PlayerInfo:
                        _gameConsoleView.DisplayPlayerInfo();
                        break;
                    case PlayerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting mission  parameters
        /// </summary>
        private void InitializeMission()
        {
            if (!_missionInitialized)
            {
                _gameConsoleView.DisplayMissionSetupIntro();
                _gamePlayer.FirstName = _gameConsoleView.DisplayGetPlayersFirstName();
                _gamePlayer.LastName = _gameConsoleView.DisplayGetPlayersLastName();
                _gamePlayer.Race = _gameConsoleView.DisplayGetPlayersRace();
                _gamePlayer.ShipLocation = _gameConsoleView.DisplayGetPlayersNewDestination().ShipLocationID;
                _missionInitialized = true;
            }
        }

        /// <summary>
        /// initialize the universe with all of the space-time locations
        /// </summary>
        private void InitializeUniverse()
        {
            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "The Bridge",
                ShipLocationID = 1,
                Description = "The Bridge, every system on the ship can be accessed through here, " +
                              "Captain Turk and Commander Dorian are fixed on their displays." +
                              "The security officer eye's you for a second, then returns to their display",
                Accessable = true
            });

            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "Medical",
                ShipLocationID = 2,
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                Accessable = false
            });

            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "Engineering",
                ShipLocationID = 3,
                Description = "This is the Engineering Bay. " +
                  "The head of Engineering's office is located here, as well as all of the tools used by engineering" +
                  "Ensign Henning's taps on a console screen, oblivious to your presence.",
                Accessable = true
            });

            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "Security",
                ShipLocationID = 4,
                Description = "This is the security office. " +
                  "Lieutenant Biggs is sitting at the desk," +
                  $"He glances up at you and asks, \"{ "Is there anything I can help you with?" }\" ",
                Accessable = true
            });

            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "Transporter Room",
                ShipLocationID = 5,
                Description = "The Transporter is used to teleport personel and objects to a destination. " +
                  "It's currently down for maintenance...",
                Accessable = true
            });

            _gameUniverse.ShipLocations.Add(new ShipLocation
            {
                Name = "Shuttle Bay",
                ShipLocationID = 6,
                Description = "This is the Shuttle Bay. " +
                  "Personnel and visitors can enter and leave the ship through here via shuttle." +
                  "There are currently three shuttles docked here.",
                Accessable = true
            });
        }

        #endregion
    }
}
