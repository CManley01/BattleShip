using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedBattleShip
{
    /// <summary>
    /// Creates and displays a char-based 2D gameboard.
    /// </summary>
    public class GameBoard
    {
        ///fields
        char[,] boardChars = new char[10, 10];

        /// <summary>
        /// properties
        /// </summary>
        public char[,] BoardChars
        {
            get
            {
                return boardChars;
            }
            set
            {
                boardChars = value;
            }
        }

        /// <summary>
        /// Fills the gameboard with a single character
        /// </summary>
        /// <param name="aChar"> The character with which to fill the board</param>
        public void FillBoard(char aChar)
        {
            for (int row = 0; row < boardChars.GetLength(0); row++)
            {
                for (int col = 0; col < boardChars.GetLength(1); col++)
                {
                    boardChars[row, col] = aChar;
                }
            }
        }

        /// <summary>
        /// Fires at specified location
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void Fire(int x, char y, List<Ship> list)
        {
            ///Do Some conversions to accept user input
            int x2 = x;
            int y2=Convert(ref x, ref y);

            ///Checks if there is already a shot at firing location
            if (boardChars[y, x] == 'X')
                Console.WriteLine("\n\nYou have already shot there, please select another target");

            ///Checks if we already hit a ship at firing location
            if (boardChars[y, x] == 'O')
                Console.WriteLine("\n\nYou have already hit an enemy ship there, please select another target");

            ///Checks if we hit an enemy ship
            if (boardChars[y, x] == 'S')
            {
                boardChars[y, x] = 'O';
                Console.WriteLine("\n\nYou hit an Enemy Ship!");
                

                ///This loop checks where the ship was hit and subtracts 1 health from the ship
                foreach (Ship ship in list)
                {
                    Console.WriteLine();
                    ///If statements to see how the ship is pivoted from Bow Coordinates
                    if (ship.BowX < ship.SternX)
                    {

                        for (int i = 0; i < ship.Length; i++)
                        {
                            
                            if (ship.BowX+i==x2 && ship.BowY==y2)
                            {
                                ship.Health--;
                            }
                        }
                        
                    }

                    if (ship.BowX > ship.SternX)
                    {
 
                        for (int i = 0; i < ship.Length; i++)
                        {
                            
                            if (ship.BowX-i == x2 && ship.BowY == y2)
                            {
                                ship.Health--; 
                            }


                        }
                        
                    }

                    if (ship.BowY < ship.SternY)
                    {

                        for (int i = 0; i < ship.Length; i++)
                        {
                           
                            if (ship.BowX == x2  && ship.BowY+i == y2)
                            {
                                ship.Health--;
                            }


                        }
                        
                    }

                    if (ship.BowY > ship.SternY)
                    {

                        for (int i = 0; i < ship.Length; i++) {
                            
                            if (ship.BowX == x2 && ship.BowY-i == y2)
                            {
                                ship.Health--;
                            }
                        }
                        
                    }
                }
            }

            ///Checks if user Missed their shot
            if (boardChars[y, x] == ' ')
            {
                boardChars[y, x] = 'X';
                Console.WriteLine("\n\nYou missed!");
            }
        }

        /// <summary>
        /// Places Ship's Tiles
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void PlaceShip(Ship ship)
        {
            ///Converts Bow Coordinates into useable numbers for the graph
            int x = ship.BowX;
            int y = ship.BowY;
            x = x - 1;
            y= y - 1;


            ///If statements places the ships depending on bow and stern locations
            if (ship.BowX < ship.SternX)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    boardChars[y, x + i] = 'S';
                     
                }
            }

            if (ship.BowX > ship.SternX)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    boardChars[y, x - i] = 'S';
                    
                    
                }
            }

            if (ship.BowY < ship.SternY)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    boardChars[y + i, x] = 'S';
                   
                }
            }

            if (ship.BowY > ship.SternY)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    boardChars[y - i, x] = 'S';
                   
                }
            }

        }

        public Boolean Validate(Ship ship)
        {
            ///Converts Bow Coordinates into useable numbers for the graph
            int x = ship.BowX;
            int y = ship.BowY;
            x = x - 1; y=y-1;

            ///Checks if the boat is on the grid
            if (ship.BowX < 1 || ship.BowY < 1 || ship.SternX < 1 || ship.SternY < 1)
            {
               
                return false;
            }

            if (ship.BowX > 10 || ship.BowY > 10 || ship.SternX > 10 || ship.SternY > 10)
            {
              
                return false;
            }

            ///checks if ship is valid depending on its location.
            if (ship.BowX < ship.SternX)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (boardChars[y, x + i] == 'S')
                    {
                        return false;
                    }
                }
            }

            if (ship.BowX > ship.SternX)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (boardChars[y, x - i] == 'S')
                        return false;
                }
            }

            if (ship.BowY < ship.SternY)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (boardChars[y + i, x] == 'S')
                    {
                        return false;
                    }
                }
            }

            if (ship.BowY > ship.SternY)
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (boardChars[y - i, x] == 'S')
                    {
                        return false;
                    }
                }
            }

            
            return true;
        }
           
        /// <summary>
            /// Sets a random location for the ship
            /// </summary>
            /// <param name="ship"></param>
        public void SetShip(Ship ship)
            {
                ///Sets Bow X&Y to random value between 0-9
                Random random = new Random();
                ship.BowX = random.Next(1, 11);
                ship.BowY = random.Next(1, 11);

                ///Switch case randomized what direction the boat pivots from its Bow Location
                int x = random.Next(4);
                switch (x)
                {
                    case 0:
                        ship.SternX = ((ship.BowX - ship.Length) + 1);
                        ship.SternY = ship.BowY;
                        break;
                    case 1:
                        ship.SternX = ((ship.BowX + ship.Length) - 1);
                        ship.SternY = ship.BowY;
                        break;
                    case 2:
                        ship.SternY = ((ship.BowY - ship.Length) + 1);
                        ship.SternX = ship.BowX;
                        break;
                    case 3:
                        ship.SternY = ((ship.BowY + ship.Length) - 1);
                        ship.SternX = ship.BowX;
                        break;
                    default:
                        break;
                }
            }

        /// <summary>
            /// Displays the current state of the gameboard
            /// </summary>
        public void Display()
            {


            char[] letters = { 'A','B','C','D','E','F','G','H','I','J' };
            DrawLine();
           
            Console.Write("   |");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 ");
            Console.ResetColor();
           
            Console.Write("|");
            Console.WriteLine();
            for (int row = 0; row < boardChars.GetLength(0); row++)
                {


                    DrawLine();

                Console.BackgroundColor = ConsoleColor.DarkCyan;

                Console.Write($" {letters[row]} ");
                Console.ResetColor();
                Console.Write("|");
                   

                for (int col = 0; col < boardChars.GetLength(1); col++)
                    {
                    if (boardChars[row, col] != 'S')
                    {
                        Console.Write($" {boardChars[row, col]} |");
                    }
                    else
                    {
                        Console.Write("   |");
                    }
                        
                    
                    }
                    Console.WriteLine();
                }
                DrawLine();
            }

        /// <summary>
        /// Displays the board but without any cheats
        /// </summary>
        public void CheatsDisplay()
        {

            ///Array in order to make the Coordinate Table
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            DrawLine();

            Console.Write("   |");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 ");
            Console.ResetColor();

            Console.Write("|");
            Console.WriteLine();
            for (int row = 0; row < boardChars.GetLength(0); row++)
            {


                DrawLine();

                Console.BackgroundColor = ConsoleColor.DarkCyan;

                Console.Write($" {letters[row]} ");
                Console.ResetColor();
                Console.Write("|");


                for (int col = 0; col < boardChars.GetLength(1); col++)
                {
                   
                        Console.Write($" {boardChars[row, col]} |");
                    


                }
                Console.WriteLine();
            }
            DrawLine();
        }

        /// <summary>
        /// Draws a horizontal line
        /// </summary>
        private void DrawLine()
            {
                Console.Write("-");
                for (int dash = 0; dash < boardChars.GetLength(1) * 4.3; dash++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();

            }

        /// <summary>
            /// Converts user data to fit the graph
            /// </summary>
            /// <param name="X"></param>
            /// <param name="Y"></param>
        private static int Convert(ref int x, ref char y)
            {
            int yz;
            switch (y)
            {
                case 'A':
                    x = x - 1;
                    y = (char)0;
                   yz= y+1;
                    return yz;

                case 'a':
                    x = x - 1;
                    y = (char)0;
                    yz = y+1;
                    return yz;

                case 'B':
                    x = x - 1;
                    y = (char)1;
                    yz = y + 1;
                    return yz;

                case 'b':
                    x = x - 1;
                    y = (char)1;
                    yz = y + 1;
                    return yz;

                case 'C':
                    x = x - 1;
                    y = (char)2;
                    yz = y + 1;
                    return yz;

                case 'c':
                    x = x - 1;
                    y = (char)2;
                    yz = y + 1;
                    return yz;

                case 'D':
                    x = x - 1;
                    y = (char)3;
                    yz = y + 1;
                    return yz;

                case 'd':
                    x = x - 1;
                    y = (char)3;
                    yz = y + 1;
                    return yz;

                case 'E':
                    x = x - 1;
                    y = (char)4;
                    yz = y + 1;
                    return yz;

                case 'e':
                    x = x - 1;
                    y = (char)4;
                    yz = y + 1;
                    return yz;
                    

                case 'F':
                    x = x - 1;
                    y = (char)5;
                    yz = y + 1;
                    return yz;

                case 'f':
                    x = x - 1;
                    y = (char)5;
                    yz = y + 1;
                    return yz;

                case 'G':
                    x = x - 1;
                    y = (char)6;
                    yz = y + 1;
                    return yz;

                case 'g':
                    x = x - 1;
                    y = (char)6;
                    yz = y + 1;
                    return yz;

                case 'H':
                    x = x - 1;
                    y = (char)7;
                    yz = y + 1;
                    return yz;

                case 'h':
                    x = x - 1;
                    y = (char)7;
                    yz = y + 1;
                    return yz;

                case 'I':
                    x = x - 1;
                    y = (char)8;
                    yz = y;
                    return yz;

                case 'i':
                    x = x - 1;
                    y = (char)8;
                    yz = y + 1;
                    return yz;

                case 'J':
                    x = x - 1;
                    y = (char)9;
                    yz = y;
                    return yz;
                   

                case 'j':
                    x = x - 1;
                    y = (char)9;
                    yz = y + 1;
                    return yz;
                    

                default:
                    yz = y;
                    return yz;
                   
            }
        }
        }
    }

