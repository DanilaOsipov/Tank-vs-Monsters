using System.Collections.Generic;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/LevelConfig")]
    public class LevelConfig : Common.Config
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private List<EnemyPoolConfig> _enemyPoolConfigs;
        [SerializeField] private List<ProjectilePoolConfig> _projectilePoolConfigs;
        [SerializeField] private List<EnemySpawnerConfig> _spawnerConfigs;
        [SerializeField] private List<RelationshipEntity> _entityRelationships;

        public PlayerConfig PlayerConfig => _playerConfig;

        public List<EnemyPoolConfig> EnemyPoolConfigs => _enemyPoolConfigs;

        public List<ProjectilePoolConfig> ProjectilePoolConfigs => _projectilePoolConfigs;

        public List<EnemySpawnerConfig> SpawnerConfigs => _spawnerConfigs;

        public List<RelationshipEntity> EntityRelationships => _entityRelationships;
    }
}