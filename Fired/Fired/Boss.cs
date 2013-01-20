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

namespace Fired
{
    class Boss : Character
    {
        public Boss(int initX, int initY, int speed) :
            base(initX, initY, speed)
        {

        }

        // Load the object content
        public override void load(ContentManager content, Texture2D texture_)
        {
            texture = texture_;
        }

        // Update object
        public void update(Tile[,] map, Vector2 heroPosition)
        {
            if (!exists)
                return;
        }
    }
}
