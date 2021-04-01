using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Monsters
{
    public class Skeleton : Monster
    {
        public override void Move(Point newPosition)
        {
            Position = newPosition;
        }
    }
}
