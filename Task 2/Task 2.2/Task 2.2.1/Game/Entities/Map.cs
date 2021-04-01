using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public List<Obstacle> Obstacles { get; private set; }
        public List<Monster> Monsters { get; private set; }
        public List<Treasure> Treasures { get; private set; }
        public Player Player { get; private set; }
    }
}
