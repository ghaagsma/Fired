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
    class Employee : Character
    {
        public Employee(int initX, int initY, int speed) :
            base(initX, initY, speed)
        {
            hitBox = new Rectangle(initX * Fired.TILE_SIZE, initY * Fired.TILE_SIZE, Fired.CHAR_SIZE, Fired.CHAR_SIZE);
            image = new Rectangle(0, 0, 300, 300);
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
