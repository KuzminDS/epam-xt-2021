using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public abstract class MovableObject : GameObject
    {
        public abstract void Move(Point newPosition);
    }
}
