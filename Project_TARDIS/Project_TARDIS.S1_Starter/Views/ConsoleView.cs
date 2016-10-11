using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TARDIS
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Universe and Player object for the ConsoleView object to use
        //
        Player _gamePlayer;
        Universe _gameUniverse;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>        
        public ConsoleView(Player gamePlayer, Universe gameUniverse)
        {
            //
            // initialize class fields
            //
            _gamePlayer = gamePlayer;
            _gameUniverse = gameUniverse;
                     
            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "- Star Trek, the text based game -";
            ConsoleUtil.HeaderText = "- Welcome! -";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage("- Thank you for playing my game,  - ");

            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("- Insert Title -");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("- Insert Info -");
            ConsoleUtil.DisplayMessage("- Insert Info -");
            Console.WriteLine();


            sb.Clear();
            sb.AppendFormat("- line 1 -");
            sb.AppendFormat("- line 2 -");
            sb.AppendFormat("- line 3 -");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();

            sb.Clear();
            sb.AppendFormat("- Insert text to user to setup game -");
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Player object
        /// </summary>
        public void DisplayMissionSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Game Setup";
            ConsoleUtil.DisplayReset();


            ConsoleUtil.DisplayMessage("You will now setup your character.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayMissionSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Mission Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your mission setup is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your player information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetPlayersFirstName()
        {
            string playersFirstName = "";

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Player's First Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your First Name:");
            playersFirstName = Console.ReadLine();

            DisplayContinuePrompt();

            return playersFirstName;
        }

        public string DisplayGetPlayersLastName()
        {
            string playersLastName = "";

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Player's Last Name";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage("Enter your Last Name:");
            playersLastName = Console.ReadLine();

            DisplayContinuePrompt();

            return playersLastName;
        }
        /// <summary>
        /// get and validate the player's race
        /// </summary>
        /// <returns>race as a RaceType</returns>
        public Player.RaceType DisplayGetPlayersRace()
        {
            bool validResponse = false;
            Player.RaceType playersRace = Player.RaceType.None;
            

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Player's Race";
                ConsoleUtil.DisplayReset();

                //
                // display all race types on a line
                //
                foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (race !=Character.RaceType.None)
                    {
                        ConsoleUtil.DisplayMessage(race.ToString());   
                    }
                }

                //
                // get user response for race
                //
                ConsoleUtil.DisplayPromptMessage("Enter your race:");
                Enum.TryParse<Character.RaceType>(Console.ReadLine(), out playersRace);
                validResponse = true;
                //
                // validate user response for race
                //


                DisplayContinuePrompt();
            }

            return playersRace;
        }

        /// <summary>
        /// get and validate the player's TARDIS destination
        /// </summary>
        /// <returns>Space-Time Location object</returns>
        public ShipLocation DisplayGetPlayersNewDestination()
        {
            bool validResponse = false;
            int locationID;
            ShipLocation nextShipLocation = new ShipLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Ship Section";
                ConsoleUtil.DisplayReset();

                //
                // display a table of space-time locations
                //
                DisplayShipSectionsTable();

                //
                // get and validate user's response for a space-time location
                //
                ConsoleUtil.DisplayPromptMessage("Enter Ship Section:");
                int ID = int.Parse(Console.ReadLine());

                nextShipLocation = _gameUniverse.GetShipLocationByID(ID);

                //
                // validate user's response for integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");
                    validResponse = true;
                    //
                    // validate user's response for range and accessible
                    //
                    try
                    {
                        
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {

                    }
                }
                //
                // user's response was not an integer
                //
                else
                {

                }

                DisplayContinuePrompt();
            }

            return nextShipLocation;
        }

        /// <summary>
        /// generate a table of space-time location names and ids
        /// </summary>
        public void DisplayShipSectionsTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //


            //
            // location name and id
            //
            foreach (ShipLocation ShipSections in _gameUniverse.ShipLocations)
            {
                string locationInfo;

                locationInfo = ShipSections.ShipLocationID.ToString() +
                    "     " + ShipSections.ShipLocationID;

                ConsoleUtil.DisplayMessage(locationInfo);
            }

        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public PlayerAction DisplayGetPlayerActionChoice()
        {
            PlayerAction playerActionChoice = PlayerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = "Player Action Choice";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("What would you like to do (Type Number).");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Look Around" + Environment.NewLine +
                    "\t" + "2. Travel" + Environment.NewLine +
                    "\t" + "3. Display All Ship Sections" + Environment.NewLine +
                    "\t" + "4. Display Player Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        playerActionChoice = PlayerAction.LookAround;
                        usingMenu = false;
                        break;
                    case '2':
                        playerActionChoice = PlayerAction.Move;
                        usingMenu = false;
                        break;
                    case '3':
                        playerActionChoice = PlayerAction.ListShipAreas;
                        usingMenu = false;
                        break;
                    case '4':
                        playerActionChoice = PlayerAction.PlayerInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        playerActionChoice = PlayerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice," + Environment.NewLine +
                            "Please choose one of the choices available.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return playerActionChoice;
        }

        /// <summary>
        /// display information about the current space-time location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Ship Location Info";
            ConsoleUtil.DisplayReset();

            Console.WriteLine(_gamePlayer.ShipLocation);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all TARDIS destinations
        /// </summary>
        public void DisplayListAllShipSections()
        {
            ConsoleUtil.HeaderText = "Ship Sections";
            ConsoleUtil.DisplayReset();


            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayPlayerInfo()
        {
            ConsoleUtil.HeaderText = "Player Info";
            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayPromptMessage($"First Name: {_gamePlayer.FirstName}" + Environment.NewLine +
            $"Last Name: {_gamePlayer.LastName}" + Environment.NewLine +
            $"Race: {_gamePlayer.Race}" + Environment.NewLine +
            "Rank: Ensign" + Environment.NewLine +
            $"Ship Location: {_gamePlayer.ShipLocation}" ); 

            DisplayContinuePrompt();
        }

        #endregion
    }
}
