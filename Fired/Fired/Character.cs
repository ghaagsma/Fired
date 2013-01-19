using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fired
{
    abstract class Character : PhysObject
    {
        public Character(int x, int y) :
            base(x,y)
        {
            
        }
    }
}
