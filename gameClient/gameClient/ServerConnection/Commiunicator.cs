using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using gameClient.HelperObject;
using gameClient.ServerConnection;
namespace Tank_Client
{
    class Commiunicator
    {
        static Socket socket = null; 
        static bool error = false;    
        static TcpListener listener ;
        static System.Net.Sockets.TcpClient clientSocket;     //create a TcpCLient socket to connect to server
        static NetworkStream stream=null;
       
       
      //  static map mp = null;
        public Commiunicator()
        {
        }
        public static void sendData(String s)
        {
            try
            {
                clientSocket = new System.Net.Sockets.TcpClient(); 
                //connecting to server socket with port 6000
                clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 6000);
                stream = clientSocket.GetStream();

                //joining message to server
                byte[] ba = Encoding.ASCII.GetBytes(s);

                for (int x = 0; x < ba.Length; x++)
                {
                    Console.WriteLine(ba[x]);
                }

                stream.Write(ba, 0, ba.Length);        //send join# to server
                stream.Flush();
                stream.Close();          //close network stream
            }
            catch (Exception e)
            {

            }
            finally {
                clientSocket.Close();
            }
        }




        public static String receiveData()
        {
            try
            {
                //Creating listening Socket
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
                Console.WriteLine("Waiting for server response");

                //Starts listening
                listener.Start();
                //Establish connection upon server request
                while (true)
                {

                    socket = listener.AcceptSocket();   

                    Console.WriteLine("Connetion is established");

                    //Fetch the messages from the server
                    int asw = 0;
                    int count = 2;
                    //create a network stream using connecion
                    NetworkStream serverStream = new NetworkStream(socket);
                    List<Byte> inputStr = new List<byte>();


                    //fetch messages from  server
                    while (asw != -1)
                    {
                        count++;
                        asw = serverStream.ReadByte();
                        inputStr.Add((Byte)asw);
                    }

                    String messageFromServer = Encoding.UTF8.GetString(inputStr.ToArray());
                    serverStream.Close();       //close the netork stream

                    return messageFromServer;
                   // Console.WriteLine("Response from server to join " + torkenizer.serverJoinMsg(messageFromServer));
                    //torkenizer.tokenizeMessage(messageFromServer);
                    //Console.WriteLine(messageFromServer);
                   
    

                }
            }
            catch (Exception e)
            {
                return null;
                Console.WriteLine("Communication (RECEIVING) Failed! \n " + e.StackTrace);
                error= true;
            }
            finally
            {
                if (socket != null)
                    if (socket.Connected)
                        socket.Close();
                if (error)
                   receiveData();
            }
        }
    }
}
