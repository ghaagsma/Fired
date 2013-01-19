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
        protected int destX;
        protected int destY;

        public SecurityGuard(int initX, int initY, int speed, int destX_, int destY_) :
            base(initX, initY, speed)
        {
            destX = destX_;
            destY = destY_;
        }

        // Load the object content
        public override void load(ContentManager content)
        {

        }

        // Update object
        public void update(Tile[,] map, Vector2 heroPosition)
        {
            if (!exists)
                return;

            velocity.X = position.X - heroPosition.X;
            velocity.Y = position.Y - heroPosition.Y;

            velocity.Normalize();
            velocity.X *= speed;
            velocity.Y *= speed;

            mapCollide(map);
        }

        // Handle collisions with other objects in map
        public override void objectCollide(PhysObject other)
        {

        }
    }
}
