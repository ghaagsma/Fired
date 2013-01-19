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
    class Hero : Character
    {


        public Hero(int x, int y) :
            base(x, y)
        {
            hitBox = new Rectangle();
            image = new Rectangle(0, 0, 300, 300);
        }

        // Load the object content
        public override void load(ContentManager content)
        {
            texture = content.Load<Texture2D>("manWithKnife");
        }

        // Update object
        public override void update()
        {

        }

        // Handle collisions with map tiles
        public override void mapCollide(Tile[,] tiles)
        {

        }

        // Handle collisions with other objects in map
        public override void objectCollide(PhysObject other)
        {

        }
    }
}
