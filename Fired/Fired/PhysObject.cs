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
    abstract class PhysObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected Rectangle hitBox;

        public PhysObject(int x, int y)
        {
            position.X = x * Map.TILE_SIZE;
            position.Y = y * Map.TILE_SIZE;
            velocity.X = 0;
            velocity.Y = 0;
        }

        // Load the object content
        public virtual void load(ContentManager content)
        {

        }

        // Update object
        public virtual void update()
        {

        }

        // Draw object
        public virtual void draw()
        {

        }

        // Handle collisions with map tiles
        public virtual void mapCollide(Tile[,] tiles)
        {

        }

        // Handle collisions with other objects in map
        public virtual void objectCollide(PhysObject other)
        {

        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Rectangle getHitBox()
        {
            return hitBox;
        }
    }
}
