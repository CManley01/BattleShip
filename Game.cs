using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModifiedBattleShip
{
    public class Game
    {
        public void RunGame()
        {
            ///Generates a Game Board
            GameBoard board = new GameBoard();

            ///puts the ships in a list
            List<Ship> list = new List<Ship>();

            /// Creates the 6 ships for the game.
            #region
            Ship destroyer1 = new Ship();
            destroyer1.CreateDestroyer();

            Ship destroyer2 = new Ship();
            destroyer2.CreateDestroyer();

            Ship submarine1 = new Ship();
            submarine1.CreateSubmarine();

            Ship submarine2 = new Ship();
            submarine2.CreateSubmarine();

            Ship battleship = new Ship();
            battleship.CreateBattleship();

            Ship carrier = new Ship();
            carrier.CreateCarrier();
            #endregion

            ///Fills the Board with Empty Spaces
            board.FillBoard(' ');

            ///Adds the ships to the list
            list.Add(carrier);
            list.Add(battleship); 
            list.Add(submarine1); 
            list.Add(submarine2);
            list.Add(destroyer1);
            list.Add(destroyer2);

            ///initial ship placement
            PlaceShips(board, list);


            ///sets the value that will end the game once all the ships are sunk
            int winCondition = 0;

            ///Displays the menu
            Console.WriteLine("Hello!, welcome to the modified BattleShip Game.");
            Console.WriteLine("Please select what you would like to do.");
            DisplayMenu();

            ///Makes the decision for the menu
            int choice = 0;
            while (choice != 3)
            {
                ///validates user input
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    ///Game without cheats
                    if (choice == 1)
                    {
                        ///Loop for the game without cheats
                        while (winCondition < list.Count)
                        {
                            ///Displays the board and prompts user to enter target
                            board.Display();
                            Console.WriteLine("Please Enter your next Target: ");

                            ///validates user input
                            try
                            {
                                Fire(board, list);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nSorry, your input was invalid. Please try again following the prompts");
                            };

                            ///checks ship health and updates win condition
                            foreach (Ship ship in list)
                            {
                                if (ship.Health == 0)
                                {
                                    Console.WriteLine("You have Sunken a Ship!");
                                    ship.Health = 99;
                                    winCondition++;
                                }
                            }

                        }

                        ///displays winning message and menu
                        WinMessage(board);
                        DisplayMenu();

                        ///resets the board
                        RemoveShips(list);
                        board.FillBoard(' ');
                        PlaceShips(board, list);

                        ///resets game values
                        winCondition = 0;
                        destroyer1.Health = 2;
                        destroyer2.Health = 2;
                        submarine1.Health = 3;
                        submarine2.Health = 3;
                        carrier.Health = 5;
                        battleship.Health = 4;

                    }

                    ///Game with cheats
                    else if (choice == 2)
                    {
                        while (winCondition < list.Count)
                        {
                            ///Displays the board and prompts user to enter target
                            board.CheatsDisplay();
                            Console.WriteLine("Please Enter your next Target: ");

                            ///validates user input
                            try
                            {
                                Fire(board, list);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nSorry, your input was invalid. Please try again following the prompts");
                            };

                            ///checks ship health and updates win condition
                            foreach (Ship ship in list)
                            {
                                if (ship.Health == 0)
                                {
                                    Console.WriteLine("You have Sunken a Ship!");
                                    ship.Health = 99;
                                    winCondition++;
                                }
                            }

                        }
                        ///displays winning message and menu
                        WinMessage(board);
                        DisplayMenu();

                        ///resets the board
                        RemoveShips(list);
                        board.FillBoard(' ');
                        PlaceShips(board, list);

                        ///resets game values
                        winCondition = 0;
                        destroyer1.Health = 2;
                        destroyer2.Health = 2;
                        submarine1.Health = 3;
                        submarine2.Health = 3;
                        carrier.Health = 5;
                        battleship.Health = 4;


                    }

                    ///Quit Program Option
                    else if (choice == 3)
                    {
                        Console.WriteLine("\nBye, Have a good day!.");
                    }
                }

                ///Prompts user to try again
                catch
                {
                    Console.WriteLine("Invalid Input: Please select an option between 1-3");
                    DisplayMenu();
                }
            }
        }

       
        /// <summary>
        /// Displays the Ships information(Mainly just used for trouble shooting and testing
        /// </summary>
        /// <param name="list"></param>
        private static void DisplayShips(List<Ship> list)
        {
            foreach (Ship ship in list)
            {
                ship.DisplayShip();

            }
        }

        /// <summary>
        /// Fires at a board location
        /// </summary>
        /// <param name="board"></param>
        /// <param name="list"></param>
        private static void Fire(GameBoard board, List<Ship> list)
        {
            Console.WriteLine("Please enter a number(1-10):");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter a character(A-J):");
            char y = Console.ReadLine()[0];
            board.Fire(x, y, list);
        }

        /// <summary>
        /// Places the ships on the board(And validates them)
        /// </summary>
        /// <param name="board"></param>
        /// <param name="list"></param>
        private static void PlaceShips(GameBoard board, List<Ship> list)
        {
            foreach (Ship ship in list)
            {
                int k = 0;
                while (k == 0)
                {
                    board.SetShip(ship);
                    if (board.Validate(ship) == true)
                    {
                        board.PlaceShip(ship);
                        k = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the ships from the list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static object RemoveShips(List<Ship> list)
        {
            
            return list.RemoveAll;
        }

        /// <summary>
        /// Displays the Menu
        /// </summary>
        private static void DisplayMenu()
        {
          
            Console.WriteLine("1) Play without cheats");
            Console.WriteLine("2) Play with cheats");
            Console.WriteLine("3) Exit Program");
        }

        /// <summary>
        /// Message for winning the game
        /// </summary>
        /// <param name="board"></param>
        private static void WinMessage(GameBoard board)
        {
            board.Display();
            Console.WriteLine();
            Console.WriteLine("All of the Battle Ships have been sunk.");
            Console.WriteLine("Congratulations, you have won!");
            Console.WriteLine("What would you like to do now?\n");
        
        }
    }

}