using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fired
{
    class Map
    {
        public const int MAP_WIDTH = 20;
        public const int MAP_HEIGHT = 15;

        int level;
        Tile[,] tiles;
        Texture2D tileset;
        bool done;

        public Map()
        {
            level = 0;
            tiles = new Tile[MAP_WIDTH, MAP_HEIGHT];
            for (int i = 0; i < MAP_WIDTH; ++i)
                for (int j = 0; j < MAP_HEIGHT; ++j)
                {
                    tiles[i, j] = new Tile();
                }
            done = true;
        }

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>("tiles");
        }

        public void Update()
        {
            if (done)
            {
                done = false;
                LoadNextLevel();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < MAP_WIDTH; ++i)
                for (int j = 0; j < MAP_HEIGHT; ++j)
                {
                    spriteBatch.Draw(tileset, tiles[i, j].location, tiles[i, j].imageSource, Color.White);
                }
        }

        //Change to the next level
        void LoadNextLevel()
        {
            level++;
            for (int i = 0; i < MAP_WIDTH; ++i)
                for (int j = 0; j < MAP_HEIGHT; ++j)
                {
                    tiles[i, j].type = TileType.Empty;
                    tiles[i, j].imageSource = new Rectangle(0, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    tiles[i, j].location = new Rectangle(i * Fired.TILE_SIZE, j * Fired.TILE_SIZE, Fired.TILE_SIZE, Fired.TILE_SIZE);
                }
        }

        public void Reset()
        {
            level = 0;
        }

        public bool CheckGameLose()
        {
            return false;
        }

        public bool CheckGameWin()
        {
            return false;
        }
    }
}
