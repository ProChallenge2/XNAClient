using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gameClient.ServerConnection;
using gameClient.HelperObject;
using Tank_Client;

namespace gameClient
{
    class GameEngin
    {

       
        private static map  mp = new map();

        parser tokenizer= new parser(mp); 
   

        public  void sendJoinMessage()
        {
            Commiunicator.sendData(Constant.C2S_INITIALREQUEST);
            String s = Commiunicator.receiveData();

            tokenizer.tokenizeMessage(s);

        }

        public char[,] getMap() {
            return mp.getGrid();
        }


        public void getUpdates() {
            String s = Commiunicator.receiveData();
            Console.WriteLine(s);

            tokenizer.tokenizeMessage(s);
        
        }
    }
}
