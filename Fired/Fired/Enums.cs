using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fired
{
    public enum TileType
    {
        Collision,
        Empty,
        Up
    }

    public enum GameState
    {
        Main,
        BadEnd,
        GoodEnd,
        Game
    }
}
