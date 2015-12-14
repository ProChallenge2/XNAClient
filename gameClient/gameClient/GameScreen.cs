using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using gameClient.ServerConnection;
using gameClient.HelperObject;
using Tank_Client;
using System.Threading;

namespace gameClient
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameScreen : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        Commiunicator communicator;
        GameEngin gE;

        TileMap map;
        Texture2D t;
        Texture2D backgroundTexture;

        int screenWidth;
        int screenHeight;

        public static char[,] matrix = null ;
        
        public GameScreen()
        {
            
            gE = new GameEngin();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            gE.sendJoinMessage();
            setMatrix(gE.getMap());

            // TODO: Add your initialization logic here
            map = new TileMap();
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 750;

            graphics.ApplyChanges();
            Window.Title = "Game Client";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            backgroundTexture = Content.Load<Texture2D>("backGround");

            Tile.Content = Content;
            t = new Texture2D(GraphicsDevice, 1, 1);
            t.SetData<Color>( new Color[] { Color.White }); // fill the texture with white

            map.generate(matrix, 50);
          
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

           // DrawScenery();

            map.Drow(spriteBatch);
            DrowHorizontalLineList();
            DrowVericaltalLineList();

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end)
        {
            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle =
                (float)Math.Atan2(edge.Y, edge.X);
            sb.Draw(t,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Black, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);
        }

        public static void setMatrix(char[,] grid) {
            matrix = grid;
        }


        public void DrowVericaltalLineList()
        {
            for (int x = 2; x < 12; x++) {
                DrawLine(spriteBatch, //draw line
                     new Vector2((x*50), 100), //start of line
                     new Vector2((x*50), 600) //end of line
                );
            }

        }

        public void DrowHorizontalLineList() {
            for (int x = 2; x < 12; x++)
            {
                DrawLine(spriteBatch, //draw line
                     new Vector2(100,(x*50)), //start of line
                     new Vector2(600,(x* 50)) //end of line
                );
            }
        }

        private void DrawScenery()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);

        }
    }
}
