using Common;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "ProjectilePoolConfig", menuName = "Config/ProjectilePoolConfig")]
    public class ProjectilePoolConfig : ObjectPoolConfig<ProjectileConfig>
    {
        [SerializeField] private ProjectileType _projectileType;

        public ProjectileType ProjectileType => _projectileType;
    }
}