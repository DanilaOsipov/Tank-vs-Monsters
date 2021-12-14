using System.Collections.Generic;
using System.Linq;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public class LevelModel : Common.Model<LevelConfig>
    {
        private List<IEntityModel> _allEntityModels = new List<IEntityModel>();
        
        public PlayerModel PlayerModel { get; }
        public List<EnemyPoolModel> EnemyPoolModels { get; } = new List<EnemyPoolModel>();
        public List<ProjectilePoolModel> ProjectilePoolModels { get; } = new List<ProjectilePoolModel>();
        public List<EnemySpawnerModel> EnemySpawnerModels { get; } = new List<EnemySpawnerModel>();
        public BoxCollider2D BoxCollider2D { get; set; }
        public bool IsUpdating { get; set; } = true;

        public LevelModel(LevelConfig config) : base(config)
        {
            PlayerModel = new PlayerModel(config.PlayerConfig);
            _allEntityModels.Add(PlayerModel);
            foreach (var enemyPoolModel in config.EnemyPoolConfigs
                .Select(enemyPoolConfig => new EnemyPoolModel(enemyPoolConfig)))
            {
                EnemyPoolModels.Add(enemyPoolModel);
                _allEntityModels.AddRange(enemyPoolModel.Elements);
            }
            foreach (var projectilePoolModel in config.ProjectilePoolConfigs
                .Select(projectilePoolConfig => new ProjectilePoolModel(projectilePoolConfig)))
            {
                ProjectilePoolModels.Add(projectilePoolModel);
                _allEntityModels.AddRange(projectilePoolModel.Elements);
            }
            foreach (var enemySpawnerModel in config.SpawnerConfigs
                .Select(spawnerConfig => new EnemySpawnerModel(spawnerConfig)))
            {
                EnemySpawnerModels.Add(enemySpawnerModel);
            }
        }

        public IEntityModel GetEntityModel(string id) => _allEntityModels
            .FirstOrDefault(x => x.Id == id);

        public bool IsEntitiesFriendly(string idA, string idB)
        {
            var entityA = GetEntityModel(idA).Config;
            var entityB = GetEntityModel(idB).Config;
            return Config.EntityRelationships
                .Any(entityRelationship => entityRelationship.FriendlyEntities.Contains(entityA)
                                           && entityRelationship.FriendlyEntities.Contains(entityB));
        }
    }
}