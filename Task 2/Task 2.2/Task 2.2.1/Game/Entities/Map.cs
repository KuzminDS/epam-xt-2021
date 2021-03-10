using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<IObstacle> Obstacles { get; private set; }
        public List<IMonster> Monsters { get; private set; }
        public List<ITreasure> Treasures { get; private set; }
        public Player Player { get; private set; }
    }
}
