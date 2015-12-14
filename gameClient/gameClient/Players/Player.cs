using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameClient.Players
{
    class Player
    {
        private Boolean shot = false;
        private int pointsEarned = 0;
        private int coins = 0;
        private int health = 0;
        private bool isAlive = true;
        private bool invalidCell = false;

        public int playerNumber { get; set; }
        public int playerLocationX { get; set; }
        public int playerLocationY { get; set; }
        public int direction { get; set; }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }
        public int Points
        {
            get { return pointsEarned; }
            set { pointsEarned = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }


        public Boolean Shot
        {
            get { return shot; }
            set { shot = value; }
        }

        public override string ToString()
        {
            return "Player Number " + this.playerNumber + "\n X Coordinate " + this.playerLocationX
                + "\n Y Coordinate " + this.playerLocationY + "\n Current Direction " + this.direction
                ;
        }
    }
}
