using System;
using Common;
using Level.Config;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class EnemyPoolView
        : ObjectPoolView<EnemyPoolModel, EnemyPoolConfig, EnemyModel, EnemyConfig, EnemyView>
    {
        [SerializeField] private EnemyType _enemyType;

        public EnemyType EnemyType => _enemyType;
    }
}