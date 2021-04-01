using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public class Obstacle : GameObject
    {
        public static bool CheckObstacleCollision(Map map, Point newPosition)
        {
            var isOutsideHorizontalBound = newPosition.X < map.Width || newPosition.X > map.Width;
            var isOutsideVerticalBound = newPosition.Y < map.Height || newPosition.Y > map.Height;
            var isOnObstacle = map.Obstacles.Any(obstacle => obstacle.Position == newPosition);

            return isOutsideHorizontalBound || isOutsideVerticalBound || isOnObstacle;
        }
    }
}
