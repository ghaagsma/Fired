using System;
using System.Collections.Generic;
using System.IO;
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
        public const int MAP_COLS = 20;
        public const int MAP_ROWS = 15;

        int level;
        Tile[,] tiles;
        Texture2D tileset;
        bool levelFinished;
        Hero hero;
        List<Employee> employees;
        List<Swat> swat;

        public Map()
        {
            level = 0;
            tiles = new Tile[MAP_ROWS, MAP_COLS];
            for (int i = 0; i < MAP_ROWS; ++i)
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    tiles[i, j] = new Tile();
                    tiles[i, j].location = new Rectangle(j * Fired.TILE_SIZE, i * Fired.TILE_SIZE, Fired.TILE_SIZE, Fired.TILE_SIZE);
                }
            levelFinished = true;
        }

        public void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>("tiles");
        }

        public void Update()
        {
            if (levelFinished)
            {
                levelFinished = false;
                LoadNextLevel();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < MAP_ROWS; ++i)
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    spriteBatch.Draw(tileset, tiles[i, j].location, tiles[i, j].imageSource, Color.White);
                }
        }

        //Change to the next level
        void LoadNextLevel()
        {
            level++;

            //Make file name and open file
            string fileName = "level" + level.ToString() + ".txt";
            StreamReader sr = new StreamReader(fileName);
            string [] line;

            //Get tiles from file
            for (int i = 0; i < MAP_ROWS; ++i)
            {
                //Read a line in and split each character at the space
                line = sr.ReadLine().Split(' '); 
                for (int j = 0; j < MAP_COLS; ++j)
                {
                    if (line[j] == "W")
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(Fired.SOURCE_SIZE, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else if (line[j] == ".")
                    {
                        tiles[i, j].type = TileType.Empty;
                        tiles[i, j].imageSource = new Rectangle(0, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                    else
                    {
                        tiles[i, j].type = TileType.Collision;
                        tiles[i, j].imageSource = new Rectangle(0, 0, Fired.SOURCE_SIZE, Fired.SOURCE_SIZE);
                    }
                }
            }

            //Add player

            sr.Close();
        }

        public void Reset()
        {
            level = 0;
            levelFinished = true;
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
