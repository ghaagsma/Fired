using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fired
{
    public enum TileType
    {
        Collision,
        Empty
    }

    public enum GameState
    {
        Main,
        BadEnd,
        GoodEnd,
        Game
    }
}
