using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Fired
{
    public struct Tile
    {
        public TileType type;
        public Rectangle location, imageSource;
    }

    public struct IntVector
    {
        public int X, Y;

        public IntVector(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
