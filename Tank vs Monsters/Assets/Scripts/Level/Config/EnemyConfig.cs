using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig")]
    public class EnemyConfig : EntityConfig, IHealableConfig, IDefencableConfig, IDamagerConfig
    {
        [SerializeField] private EnemyType _type;
        [SerializeField] private EnemyHealthEntity _healthEntity;
        [SerializeField] private EnemyDefenceEntity _defenceEntity;
        [SerializeField] private EnemyDamageEntity _damageEntity;
        
        public HealthEntity HealthEntity => _healthEntity;
        
        public DefenceEntity DefenceEntity => _defenceEntity;
        
        public DamageEntity DamageEntity => _damageEntity;

        public EnemyType Type => _type;
    }
}