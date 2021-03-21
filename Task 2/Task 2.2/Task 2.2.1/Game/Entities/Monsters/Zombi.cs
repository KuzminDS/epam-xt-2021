using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Monsters
{
    class Zombi : IMonster
    {
        public Point Position { get; private set; }

        public void Move(Point newPosition)
        {
            Position = newPosition;
        }
    }
}
