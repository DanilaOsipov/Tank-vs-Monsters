using System;
using Common;
using Level.Config;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class ProjectilePoolView : ObjectPoolView<ProjectilePoolModel, ProjectilePoolConfig,
        ProjectileModel, ProjectileConfig, ProjectileView>
    {
        [SerializeField] private ProjectileType _projectileType;

        public ProjectileType ProjectileType => _projectileType;
    }
}