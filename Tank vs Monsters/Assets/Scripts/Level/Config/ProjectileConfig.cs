using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Config/ProjectileConfig")]
    public class ProjectileConfig : EntityConfig, IDamagerConfig
    {
        [SerializeField] private ProjectileType _type;
        [SerializeField] private ProjectileDamageEntity _damageEntity;

        public DamageEntity DamageEntity => _damageEntity;

        public ProjectileType Type => _type;
    }
}