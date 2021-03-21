using Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameLogic
    {
        private Map _map;
        private bool _isWon;
        private bool _isLost;

        public void Start()
        {
            InitializeComponents();

            _isWon = false;
            _isLost = false;

            while (!_isWon && !_isLost)
            {
                var newPosition = new Point(); //logic for getting user moves was missed

                CheckMonsterCollision(_map.Player.Position);

                if (!CheckObstacleCollision(newPosition))
                    _map.Player.Move(newPosition);

                CheckMonsterCollision(newPosition);

                CheckTreasureCollision(newPosition);

                MoveMonsters();
            }
        }

        private bool CheckObstacleCollision(Point newPosition)
        {
            var isOutsideHorizontalBound = newPosition.X < _map.Width || newPosition.X > _map.Width;
            var isOutsideVerticalBound = newPosition.Y < _map.Height || newPosition.Y > _map.Height;
            var isOnObstacle = _map.Obstacles.Any(obstacle => obstacle.Position == newPosition);

            return isOutsideHorizontalBound || isOutsideVerticalBound || isOnObstacle;
        }

        private void CheckMonsterCollision(Point newPosition)
        {
            _isLost = _map.Monsters.Any(m => m.Position == newPosition);
        }

        private void CheckTreasureCollision(Point newPosition)
        {
            var treasure = _map.Treasures.FirstOrDefault(t => t.Position == newPosition);

            if (treasure != null)
            {
                treasure.AddWealth(_map.Player);
                _map.Treasures.Remove(treasure);

                if (_map.Treasures.Count == 0)
                    _isWon = true;
            }
        }

        private void MoveMonsters()
        {
            foreach (var monster in _map.Monsters)
            {
                var newPos = new Point(); //getting a new random valid position for monster
                if (!CheckObstacleCollision(newPos))
                    monster.Move(newPos);
            }
        }

        private void InitializeComponents()
        {
            InitializeMap();
            InitializeObstacles();
            InitializeMonsters();
            InitializeTreasures();
            InitializePlayer();
        }

        private void InitializePlayer()
        {
            throw new NotImplementedException();
        }

        private void InitializeTreasures()
        {
            throw new NotImplementedException();
        }

        private void InitializeMonsters()
        {
            throw new NotImplementedException();
        }

        private void InitializeObstacles()
        {
            throw new NotImplementedException();
        }

        private void InitializeMap()
        {
            throw new NotImplementedException();
        }
    }
}
