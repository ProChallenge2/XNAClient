using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameClient.HelperObject;
using Tank_Client;
using gameClient.ServerConnection;

namespace gameClient.ArtificialIntelligence
{
    class AI
    {
        char[,] grid;
        private  map mp ;
        public AI(char[,] grid)
        {
            this.grid = grid;
            mp = new map();
        }

        public string getNextMove(int CurrentX, int CurrentY)
        {
            Console.WriteLine("getNextMove");
            int val = mp.neighbour(CurrentX, CurrentY);
            Console.WriteLine(val + "******************************");
            if (val == 3)
                return Constant.UP;
            else if (val == 1)
                return Constant.DOWN;
            else if (val == 2)
                return Constant.LEFT;
            else if (val == 0)
                return Constant.RIGHT;
            else
                return Constant.SHOOT;
        }
    }
}
