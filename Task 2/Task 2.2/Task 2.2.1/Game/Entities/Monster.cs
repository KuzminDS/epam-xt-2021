using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public abstract class Monster : MovableObject
    {
        public static GameOverState CheckMonsterCollision(Map map, Point newPosition)
        {
            if (map.Monsters.Any(m => m.Position == newPosition))
                return GameOverState.Lost;

            return GameOverState.None;
        }
    }
}
