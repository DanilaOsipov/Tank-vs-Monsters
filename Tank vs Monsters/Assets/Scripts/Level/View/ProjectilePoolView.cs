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

        public event Action<ProjectileType, string, Collision2D> OnProjectileCollisionEnter 
            = delegate(ProjectileType type, string id, Collision2D collision) { };
        
        protected override void OnElementCollisionEnterHandler(string id, Collision2D collision)
        {
            OnProjectileCollisionEnter(_projectileType, id, collision);
        }
    }
}