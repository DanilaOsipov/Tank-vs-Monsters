using System;
using Level.Config;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class ProjectileView : EntityView<ProjectileModel, ProjectileConfig>
    {
        private TrailRenderer _trailRenderer;

        private void Awake()
        {
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        protected override void OnIsActiveChangedHandler(bool isActive)
        {
            base.OnIsActiveChangedHandler(isActive);
            if (isActive) return;
            if (_trailRenderer != null) _trailRenderer.Clear();
        }
    }
}