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
    class SecurityGuard : Character
    {
        protected int srcX;
        protected int srcY;
        protected int destX;
        protected int destY;

        public SecurityGuard(int initX, int initY, int speed, int destX_, int destY_) :
            base(initX, initY, speed)
        {
            srcX = initX * Fired.TILE_SIZE;
            srcY = initY * Fired.TILE_SIZE;
            destX = destX_ * Fired.TILE_SIZE;
            destY = destY_ * Fired.TILE_SIZE;
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

            velocity.X = destX - position.X;
            velocity.Y = destY - position.Y;

            velocity.Normalize();
            velocity.X *= speed;
            velocity.Y *= speed;

            mapCollide(map);

            // Check if guard has reached destination
            if ((velocity.X >= 0 && position.X >= destX - 1) || (velocity.X <= 0 && position.X <= destX + 1))
            {
                if ((velocity.Y >= 0 && position.Y >= destY - 1) || (velocity.Y <= 0 && position.Y <= destY + 1))
                {
                    int tempDestX = destX;
                    int tempDestY = destY;
                    destX = srcX;
                    destY = srcY;
                    srcX = tempDestX;
                    srcY = tempDestY;
                }
            }
        }

        // Handle collisions with other objects in map
        public override void objectCollide(PhysObject other)
        {

        }
    }
}
