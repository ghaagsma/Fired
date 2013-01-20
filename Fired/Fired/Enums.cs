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

    public enum CharacterAnimationState
    {
        FaceFront = 0,
        FaceBack = 1,
        FaceRight = 2,
        FaceLeft = 3,
        Dead = 4
    }
}
