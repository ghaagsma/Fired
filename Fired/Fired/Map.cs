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
        public const int MAP_WIDTH = 45;
        public const int MAP_HEIGHT = 35;

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
