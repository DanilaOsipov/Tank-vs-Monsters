using System.Linq;
using Common;
using Level.Model;
using Level.Other;

namespace Level.Command
{
    public class CheckEnemyHealthCommand : ICommand
    {
        private readonly EnemyType _enemyType;
        private readonly string _id;
        private readonly LevelModel _levelModel;
        
        public CheckEnemyHealthCommand(EnemyType enemyType, string id, LevelModel levelModel)
        {
            _enemyType = enemyType;
            _id = id;
            _levelModel = levelModel;
        }
        
        public void Execute()
        {
            var enemyPoolModel = _levelModel.EnemyPoolModels
                .FirstOrDefault(x => x.Config.EnemyType == _enemyType);
            var enemyModel = enemyPoolModel.Elements
                .FirstOrDefault(x => x.Id == _id);
            if (enemyModel.HealthModel.Health > 0) return;
            enemyModel.HealthModel.Health = enemyModel.Config.HealthEntity.Health;
            enemyModel.IsActive = false;
            var spawnEnemyCommand = new SpawnEnemyCommand(_enemyType, _levelModel);
            spawnEnemyCommand.Execute();
        }
    }
}