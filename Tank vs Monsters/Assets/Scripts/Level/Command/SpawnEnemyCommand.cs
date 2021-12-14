using System;
using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level.Command
{
    public class SpawnEnemyCommand : ICommand
    {
        private readonly EnemyType _type;
        private readonly LevelModel _levelModel;

        public SpawnEnemyCommand(EnemyType type, LevelModel levelModel)
        {
            _type = type;
            _levelModel = levelModel;
        }
        
        public void Execute()
        {
            var enemyPoolModel = _levelModel.EnemyPoolModels
                .FirstOrDefault(x => x.Config.EnemyType == _type);
            if (enemyPoolModel == null) return;
            var enemyModel = enemyPoolModel.Elements.FirstOrDefault(x => !x.IsActive);
            if (enemyModel == null) return;
            var spawnerModel = _levelModel.EnemySpawnerModels
                .FirstOrDefault(x => x.Config.EnemyType == _type);
            if (spawnerModel == null) return;
            var spawnPoint = spawnerModel.SpawnPoints[Random.Range(0,
                spawnerModel.SpawnPoints.Count)];
            enemyModel.Transform.position = spawnPoint.position;
            enemyModel.Transform.up = _levelModel.PlayerModel.Transform.position 
                                      - enemyModel.Transform.position;
            enemyModel.IsActive = true;
        }
    }
}