using System;
using System.Threading;
using gameClient.ServerConnection;
using gameClient.HelperObject;
using Tank_Client;

namespace gameClient
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static CancellationTokenSource cts = new CancellationTokenSource();
        static void Main(string[] args)
        {

            using (GameScreen game = new GameScreen())
            {
                game.Run();
            }

           
        }
        
    }
#endif
}

