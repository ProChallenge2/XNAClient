using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameClient
{
    class Tile
    {
        protected Texture2D texture;
        private Rectangle rectangle;
        private static ContentManager content;


        public Rectangle Rectangle 
        {
            get { return rectangle; }
            protected set{rectangle = value;}
        }

        public static ContentManager Content 
        {
            protected get { return content; }
            set { content = value; }
        }

        public void DrowTile (SpriteBatch spriteBitch){
            spriteBitch.Draw(texture, rectangle, Color.White);
        }
    }

    class CollisionTile : Tile 
    {
        public CollisionTile(String i, Rectangle newRectangle)
        {

            if (i.Equals("<") || i.Equals(">") || i.Equals("^") || i.Equals("v"))
            {
                texture = Content.Load<Texture2D>("tank");
            }

            else 
            {
                texture = Content.Load<Texture2D>("Tile"+i);
            }
            this.Rectangle = newRectangle;
        }
    
    }
}
