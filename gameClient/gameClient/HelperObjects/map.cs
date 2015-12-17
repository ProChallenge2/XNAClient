using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace gameClient.ServerConnection
{


    class map
    {

        private static map instance = new map();
        public static char[,] grid { get; set; }

        public map()
        {
            grid = new char[10, 10];
            initGrid();
        }

        // implement singlton Pattern
        public map getInstance() 
        {
            if (instance != null)
            {
                return instance;
            }
            else 
            {
                return new map();
            }
        }

        // initialize the grid to store data about game screen that sedn by server
        public void initGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = '0';
                }
            }
        }

        /*
         * this method return grid
         */
        public char[,] getGrid()
        {
            return grid;
        }

        /*
        * this method set the grid
        */
        public void setGrid(char[,] gd)
        {

            Console.WriteLine("Settinggggggggggggggggggggggggggggggggggg");
            grid = gd;
        }
        public int neighbour(int x, int y)
        {
            char[,] newGrid = null;
            newGrid = getGrid();
            if (x + 1 < 10)
            {
                if (newGrid[x + 1, y] == '0')
                    return 0;
            }
            else if (x - 1 >= 0)
            {
                if (newGrid[x - 1, y] == '0')
                    return 2;
            }
            else if (y + 1 < 10)
            {
                if (newGrid[x, y + 1] == '0')
                    return 1;
            }
            else if (y - 1 >= 0)
            {
                if (newGrid[x, y - 1] == '0')
                    return 3;
            }
            return -1;
        }

        /*
         * this is to display grid in console
         */
        public void showGrid()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
            }
            Console.WriteLine("");
        }


        /*
         * this method update grid according to water coordinate
         */
        public void setwaterCordinates(String[] array)
        {
            char[] waterD = { ';', ',', '#', '?' };
            String[] water = array[4].Split(waterD);

            for (int k = 0; k < water.Length - 1; k += 2)
            {
                grid[Int32.Parse(water[k + 1]), Int32.Parse(water[k])] = '3';
            }
        
        }

        /*
        * this method update grid according to Bricks coordinate
        */
        public void setBriksCordinates(String[] array)
        {

            char[] brickD = { ';', ',' };
            String[] bricks = array[2].Split(brickD);


            for (int k = 0; k < bricks.Length; k += 2)
            {
                grid[Int32.Parse(bricks[k + 1]), Int32.Parse(bricks[k])] = '1';
            }


        }

        /*
        * this method update grid according to stone coordinate
        */

        public void setStoneCordinates(String[] array)
        {

            char[] stoneD = { ';', ',' };
            String[] stones = array[3].Split(stoneD);

            for (int k = 0; k < stones.Length; k += 2)
            {
                grid[Int32.Parse(stones[k + 1]), Int32.Parse(stones[k])] = '2';
            }

        }

    }
}
