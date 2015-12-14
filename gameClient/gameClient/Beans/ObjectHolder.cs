using gameClient.Beans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameClient.HelperObjects
{
    class ObjectHolder
    {
        protected List<LifePacket> lifePacketList = new List<LifePacket>();
        protected List<CoinPile> CoinPileList = new List<CoinPile>();
        protected List<Stone> StoneList = new List<Stone>();
        protected List<Brick> BrickList = new List<Brick>();
        protected List<Water> WaterList = new List<Water>();

    }
}
