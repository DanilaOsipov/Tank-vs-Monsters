using Common;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "EnemyPoolConfig", menuName = "Config/EnemyPoolConfig")]
    public class EnemyPoolConfig : ObjectPoolConfig<EnemyConfig>
    {
        [SerializeField] private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;
    }
}