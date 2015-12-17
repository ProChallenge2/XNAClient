using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gameClient
{
    class TileMap
    {
        private List<CollisionTile> collitionTiles = new List<CollisionTile>();
        private int width, height;

        public List<CollisionTile> CollitionTile
        {
            get { return collitionTiles; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public TileMap()
        {

        }

        public void generate(char[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    char number = map[y, x];

                    collitionTiles.Add(new CollisionTile(number.ToString(), new Rectangle(((x * size)+100), ((y * size)+100), size, size)));

                    width = (x + 1) * size;
                    height = (y + 1) * size;

                }
            }

            Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
            }
            Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww");
        }

        public void Drow(SpriteBatch spritebatch)
        {
            foreach (CollisionTile tile in collitionTiles)
            {

                tile.DrowTile(spritebatch);

            }
        }
    }
}
