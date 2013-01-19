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
    class PhysObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Rectangle hitBox;

        // Load the object content
        public void load(ContentManager content)
        {

        }


        public void update()
        {

        }

        public void draw()
        {

        }

        public void mapCollide(Tile[,] tiles)
        {

        }

        public void objectCollide(PhysObject other)
        {

        }
    }
}
