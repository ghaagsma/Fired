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
        public Employee(int x, int y) :
            base(x, y)
        {

        }

        // Load the object content
        public override void load(ContentManager content)
        {
            
        }

        // Update object
        public override void update(Tile[,] map)
        {
            if (!exists)
                return;
        }

        // Handle collisions with other objects in map
        public override void objectCollide(PhysObject other)
        {

        }
    }
}
