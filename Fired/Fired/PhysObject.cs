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
        protected Texture2D texture;    // Image of this object
        protected Rectangle image;      // Where in the source image to grab from
        protected Vector2 position;
        protected Vector2 velocity;
        protected Rectangle hitBox;     // Collision box

        protected bool exists;          // Whether this object exists or has been destroyed

        public PhysObject(int initX, int initY)
        {
            position.X = initX * Fired.TILE_SIZE;
            position.Y = initY * Fired.TILE_SIZE;
            velocity.X = 0;
            velocity.Y = 0;
            hitBox = new Rectangle(initX * Fired.TILE_SIZE, initY * Fired.TILE_SIZE, Fired.CHAR_SIZE, Fired.CHAR_SIZE);
            image = new Rectangle(0, 0, 300, 300);

            exists = true;
        }

        // Load the object content
        public virtual void load(ContentManager content, Texture2D texture_)
        {
            texture = texture_;
        }

        // Update object
        public virtual void update(Tile[,] map)
        {

        }

        // Draw object
        public virtual void draw(SpriteBatch spriteBatch)
        {
            if (exists)
                spriteBatch.Draw(texture, hitBox, image, Color.White);
        }

        // Handle collisions with map tiles
        public virtual void mapCollide(Tile[,] map)
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
