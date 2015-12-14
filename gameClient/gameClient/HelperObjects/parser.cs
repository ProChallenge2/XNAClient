using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameClient.Players;
using gameClient.Beans;
using gameClient.HelperObject;
using Tank_Client.beans;

namespace gameClient.ServerConnection
{
    class parser
    {
        private const String PLAYERS_FULL = "PLAYERS_FULL#";
        private const String ALREADY_ADDED = "ALREADY_ADDED#";
        private const String GAME_ALREADY_STARTED = "GAME_ALREADY_STARTED";
        
        private Player me;
        private Player player;
        LifePacket lifePack = new LifePacket();
        CoinPile coinPile = new CoinPile();
        Treasure treasure = new Treasure();

        private Player[] playr = new Player[5];


        public static char[,] grid = null;
        public map mp;
        bool a = false;
        bool b = false;


        public parser(map mp) {
            this.mp = mp;
            grid = mp.getGrid(); 
        }

        public String jointoserver()
        {
            return "JOIN#";
        }

        public int serverJoinMsg(String reply)
        {
            switch (reply)
            {
                case PLAYERS_FULL: return 1;
                case ALREADY_ADDED: return 2;
                case GAME_ALREADY_STARTED: return 3;
                default: return 0;
            }

        }

        public void tokenizeMessage(String msg)
        {
            String[] reply = msg.Split('#');

            if (reply[0] == Constant.S2C_GAMESTARTED)
            {
                Console.WriteLine("Game is started.");
            }
            else if (reply[0] == Constant.S2C_NOTSTARTED)
            {
                Console.WriteLine("Game is not started yet.");
            }

            else if (reply[0] == Constant.S2C_GAMEOVER)
            {
                Console.WriteLine("Game Over");
            }
            else if (reply[0] == Constant.S2C_GAMEJUSTFINISHED)
            {
                Console.WriteLine("Game just finished");
            }
            else if (reply[0] == Constant.S2C_ContestentSFULL)
            {
                Console.WriteLine("Players full");
            }
            else if (reply[0] == Constant.S2C_ALREADYADDED)
            {
                Console.WriteLine("Player is already added.");
            }
            else if (reply[0] == Constant.S2C_INVALIDCELL)
            {
                Console.WriteLine("INVALID_CELL");
            }

            else if (reply[0] == Constant.S2C_NOTAContestent)
            {
                Console.WriteLine("NOT_A_VALID_CONTESTANT");
            }
            else if (reply[0] == Constant.S2C_TOOEARLY)
            {
                Console.WriteLine(" TOO_QUICK");
            }
            else if (reply[0] == Constant.S2C_CELLOCCUPIED)
            {
                Console.WriteLine("CELL_OCCUPIED");
            }
            else if (reply[0] == Constant.S2C_HITONOBSTACLE)
            {
                Console.WriteLine("OBSTACLE");

            }
            else if (reply[0] == Constant.S2C_NOTALIVE)
            {
                Console.WriteLine("DEAD");
            }

            else
            {

                char[] del = { ':' };
                String[] array = reply[0].Split(del);


                if (array[0] == "I")
                {

                    Console.WriteLine("1111111111111111111111111111111111111111111111111111111111111111111111");
                   

                    mp.setBriksCordinates(array);
                    mp.setStoneCordinates(array);
                    mp.setwaterCordinates(array);
                    a = true;


                }
                else if (array[0] == "S")
                {
                    String[] arrayNew = array[1].Split(';');

                    player.playerNumber = Int32.Parse(arrayNew[0].Substring(1));
                    String[] location = arrayNew[1].Split(',');
                    player.playerLocationX = Int32.Parse(location[0]);
                    player.playerLocationY = Int32.Parse(location[1]);

                    player.direction = Int32.Parse(arrayNew[2]);

                    switch (player.direction)
                    {
                        case 0:
                            grid[player.playerLocationY, player.playerLocationX] = '^';
                            break;
                        case 1:
                            grid[player.playerLocationY, player.playerLocationX] = '>';
                            break;
                        case 2:
                            grid[player.playerLocationY, player.playerLocationX] = 'V';
                            break;
                        case 3:
                            grid[player.playerLocationY, player.playerLocationX] = '<';
                            break;

                    }
                    b = true;

                }
                else if (array[0] == "G")
                {

                    for (int i = 1; i < array.Length - 1; i++)
                    {
                        if (playr[i - 1] == null)
                        {
                            playr[i - 1] = new Player();
                        }
                        playerDetails(array[i], playr[i - 1]);
                    }

                }
                else if (array[0] == "L")
                {
                    String[] location = array[1].Split(',');
                    lifePack.locationX = Int32.Parse(location[0]);
                    lifePack.locationY = Int32.Parse(location[1]);
                    lifePack.time = Int32.Parse(array[2]);
                    grid[lifePack.locationY, lifePack.locationX] = 'L';
                }

                else if (array[0] == "C")
                {
                    String[] location = array[1].Split(',');
                    treasure.locationX = Int32.Parse(location[0]);
                    treasure.locationY = Int32.Parse(location[1]);
                    treasure.time = Int32.Parse(array[2]);
                    treasure.value = Int32.Parse(array[3]);
                    grid[treasure.locationY, treasure.locationX] = 'C';
                }


                mp.setGrid(grid);
                if (a & b)
                {
                    mp.showGrid();
                }
            }
        
        }

             public void playerDetails(String det,Player player)
        {

            String[] arNew = det.Split(';');
            grid[player.playerLocationY, player.playerLocationX] = '0';
                
            player.playerNumber = Int32.Parse(arNew[0].Substring(1));
            String[] location = arNew[1].Split(',');
            
            player.playerLocationX = Int32.Parse(location[0]);
            player.playerLocationY = Int32.Parse(location[1]);

            player.direction = Int32.Parse(arNew[2]);

            switch (player.direction)
            {
                case 0:
                    grid[player.playerLocationY, player.playerLocationX] = '^';
                    break;
                case 1:
                    grid[player.playerLocationY, player.playerLocationX] = '>';
                    break;
                case 2:
                    grid[player.playerLocationY, player.playerLocationX] = 'v';
                    break;
                case 3:
                    grid[player.playerLocationY, player.playerLocationX] = '<';
                    break;

            }

            if (arNew[3] == "0")
            {
                player.Shot = false;
            }
            else
                player.Shot = true;

            player.Health = Int32.Parse(arNew[4]);
            player.Coins = Int32.Parse(arNew[5]);
            player.Points = Int32.Parse(arNew[6]);

        }
    }
}
