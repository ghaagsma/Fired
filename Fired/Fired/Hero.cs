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

        protected int animationChoice;
        protected int animationSpeed;

        public Hero(int initX, int initY, int speed) :
            base(initX, initY, speed)
        {
            hitBox = new Rectangle(initX * Fired.TILE_SIZE, initY * Fired.TILE_SIZE, Fired.CHAR_SIZE, Fired.CHAR_SIZE);
            image = new Rectangle(0, 0, 300, 300);
            oldState = Keyboard.GetState();
            animationChoice = 0;
            animationSpeed = 40;
        }

        // Load the object content
        public override void load(ContentManager content, Texture2D texture_)
        {
            texture = texture_;
        }

        // Update object
        public override void update(Tile [,] map)
        {
            if (!exists)
                return;

            int getImageFromHeight = 0;

            if (animationChoice < animationSpeed / 4)
                getImageFromHeight = 0;
            else if (animationChoice < 2 * animationSpeed / 4)
                getImageFromHeight = 300;
            else if (animationChoice < 3 * animationSpeed / 4)
                getImageFromHeight = 600;
            else
                getImageFromHeight = 300;

            newState = Keyboard.GetState();
            velocity.X = 0;
            velocity.Y = 0;

            if (newState.IsKeyDown(Keys.Right))
            {
                velocity.X += 1;
                image = new Rectangle(600, getImageFromHeight, 300, 300);
            }
            if (newState.IsKeyDown(Keys.Left))
            {
                velocity.X -= 1;
                image = new Rectangle(900, getImageFromHeight, 300, 300);
            }

            if (newState.IsKeyDown(Keys.Up))
            {
                velocity.Y -= 1;
                image = new Rectangle(300, getImageFromHeight, 300, 300);
            }
            if (newState.IsKeyDown(Keys.Down))
            {
                velocity.Y += 1;
                image = new Rectangle(0, getImageFromHeight, 300, 300);
            }

            velocity.Normalize();
            velocity.X *= speed;
            velocity.Y *= speed;

            animationChoice++;

            if (animationChoice >= animationSpeed)
                animationChoice = 0;

            mapCollide(map);
        }
    }
}
