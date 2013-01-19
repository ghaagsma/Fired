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

        public PhysObject(int x, int y)
        {
            position.X = x;
            position.Y = y;
            velocity.X = 0;
            velocity.Y = 0;
        }

        // Load the object content
        public void load(ContentManager content)
        {

        }

        // Update object
        public void update()
        {

        }

        // Draw object
        public void draw()
        {

        }

        // Handle collisions with map tiles
        public void mapCollide(Tile[,] tiles)
        {

        }

        // Handle collisions with other objects in map
        public void objectCollide(PhysObject other)
        {

        }
    }
}
