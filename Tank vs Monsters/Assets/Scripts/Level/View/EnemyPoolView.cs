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
        
        public event Action<EnemyType, string, Collision2D> OnEnemyCollisionEnter 
            = delegate(EnemyType type, string id, Collision2D collision) { };
        
        protected override void OnElementCollisionEnterHandler(string id, Collision2D collision)
        {
            OnEnemyCollisionEnter(_enemyType, id, collision);
        }
    }
}