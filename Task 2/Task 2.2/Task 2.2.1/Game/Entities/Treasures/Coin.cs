using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities.Treasures
{
    class Coin : ITreasure
    {
        public Point Position { get; private set; }

        public void AddWealth(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
