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
        private GameOverState _gameOverState;

        public void Start()
        {
            InitializeComponents();

            RunGame();
        }

        private void RunGame()
        {
            while (_gameOverState == GameOverState.None)
            {
                var newPosition = new Point(); //logic for getting user moves was missed

                _gameOverState = Monster.CheckMonsterCollision(_map, _map.Player.Position);

                if (!Obstacle.CheckObstacleCollision(_map, newPosition))
                    _map.Player.Move(newPosition);

                _gameOverState = Monster.CheckMonsterCollision(_map, newPosition);

                _gameOverState = Treasure.CheckTreasureCollision(_map, newPosition);

                MoveMonsters();
            }
        }


        private void MoveMonsters()
        {
            foreach (var monster in _map.Monsters)
            {
                var newPos = new Point(); //getting a new random valid position for monster
                if (!Obstacle.CheckObstacleCollision(_map, newPos))
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
            _gameOverState = GameOverState.None;
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
