using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ModifiedBattleShip
{
    public class Ship
    {
        //fields
        int length;
        int bowX;
        int bowY;
        int sternX;
        int sternY;
        int health;
        char[,] coordinates;

        /// <summary>
        /// Constructor
        /// </summary>
        public Ship()
        {
        }

        /// <summary>
        /// Gets and Sets the BowX
        /// </summary>
        public int BowX { get => bowX; set => bowX = value; }

        /// <summary>
        /// Gets and sets the BowY
        /// </summary>
        public int BowY { get => bowY; set => bowY = value; }

        /// <summary>
        /// Gets and Sets the SternX
        /// </summary>
        public int SternX { get => sternX; set => sternX = value; }

        /// <summary>
        /// Gets and Sets the SternY
        /// </summary>
        public int SternY { get => sternY; set => sternY = value; }

        /// <summary>
        /// Gets and Sets Health
        /// </summary>
        public int Health { get => health; set => health = value; }

        /// <summary>
        /// Gets and Sets Length
        /// </summary>
        public int Length { get => length; set => length = value; }

        /// <summary>
        /// Gets ans Sets Coordinates
        /// </summary>
        public char[,] Coordinates { get => coordinates; set => coordinates = value; }

        /// <summary>
        /// Displays the Ship's values
        /// </summary>
        /// <param name="ship"></param>
        public void DisplayShip()
        {
            Console.WriteLine($"Length:{Length} Health:{health}\nStern X:{SternX} Stern Y:{SternY}\nBow X:{BowX} Bow Y:{BowY}\n");
        }

        /// <summary>
        /// Creates the Destroyer Ship
        /// </summary>
        /// <param name="ship"></param>
        public int CreateDestroyer()
        {
            health = 2;
            return Length = 2;
        }

        /// <summary>
        /// Creates the Submarine Ship
        /// </summary>
        /// <param name="ship"></param>
        public int CreateSubmarine()
        {
            health = 3;
            return Length = 3;
        }

        /// <summary>
        /// Creates the Battleship Ship
        /// </summary>
        /// <param name="ship"></param>
        public int CreateBattleship()
        {
            health= 4;
            return Length = 4;
        }

        /// <summary>
        /// Creates the Carrier Ship
        /// </summary>
        /// <param name="ship"></param>
        public int CreateCarrier()
        {

            health = 5;
            return Length = 5;

        }

        /// <summary>
        /// Shows Coordinates, Checks the bow and stern locations in order to do math and figure out where the rest of the ship is
        /// </summary>
        public void DisplayCoordinates(){

            

                if (BowX < SternX)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        Console.Write($"X:{BowX+j} Y:{BowY}  ");
                    }
                }

                if (BowX > SternX)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        Console.Write($"X:{BowX-j} Y:{BowY}  ");
                    }
                }

                if (BowY < SternY)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        Console.Write($"X:{BowX} Y:{BowY+j}  ");
                    }
                }

                if (BowY > SternY)
                {
                    for (int j = 0; j < Length; j++)
                    {
                        Console.Write($"X:{BowX} Y:{BowY-j}  ");
                    }
                }
            
        }


    }
    

}
