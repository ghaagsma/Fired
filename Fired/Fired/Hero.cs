﻿using System;
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
    class Hero : Character
    {
        protected KeyboardState oldState;
        protected KeyboardState newState;

        public Hero(int x, int y) :
            base(x, y)
        {
            hitBox = new Rectangle();
            image = new Rectangle(0, 0, 300, 300);
            oldState = Keyboard.GetState();
        }

        // Load the object content
        public override void load(ContentManager content)
        {
            texture = content.Load<Texture2D>("manWithKnife");
        }

        // Update object
        public override void update(Tile [,] map)
        {
            if (!exists)
                return;

            newState = Keyboard.GetState();
            velocity.X = 0;
            velocity.Y = 0;

            if(newState.IsKeyDown(Keys.Up))
                velocity.Y -= 5;
            if (newState.IsKeyDown(Keys.Right))
                velocity.X += 5;
            if (newState.IsKeyDown(Keys.Down))
                velocity.Y += 5;
            if (newState.IsKeyDown(Keys.Left))
                velocity.X -= 5;

            mapCollide(map);
        }

        // Handle collisions with other objects in map
        public override void objectCollide(PhysObject other)
        {

        }
    }
}
