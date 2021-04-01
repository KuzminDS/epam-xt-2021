using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public abstract class Treasure : GameObject
    {
        public abstract void AddWealth(Player player);

        public static GameOverState CheckTreasureCollision(Map map, Point newPosition)
        {
            var treasure = map.Treasures.FirstOrDefault(t => t.Position == newPosition);

            if (treasure != null)
            {
                treasure.AddWealth(map.Player);
                map.Treasures.Remove(treasure);

                if (map.Treasures.Count == 0)
                    return GameOverState.Won;
            }
            return GameOverState.None;
        }
    }
}
