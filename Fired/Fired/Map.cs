﻿using System;
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
    struct Tile
    {
        public TileType type;
        public Rectangle location, imageSource;
    }

    class Map
    {
        public const int TILE_SIZE = 40;
        public const int MAP_WIDTH = 45;
        public const int MAP_HEIGHT = 30;

        int level;
        Tile[,] tiles;

        public Map()
        {
            level = 0;
        }

        public void LoadContent(ContentManager content)
        {
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void LoadNextLevel()
        {
        }

        public void Reset()
        {
            level = 0;
        }

        public bool CheckGameEnd()
        {
            return false;
        }
    }
}
