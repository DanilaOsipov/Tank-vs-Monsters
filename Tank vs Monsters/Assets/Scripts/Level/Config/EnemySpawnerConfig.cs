using Common;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Config/EnemySpawnerConfig")]
    public class EnemySpawnerConfig : Common.Config
    {
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private float _spawnDelay = 3.0f;
        
        public EnemyType EnemyType => _enemyType;

        public float SpawnDelay => _spawnDelay;
    }
}