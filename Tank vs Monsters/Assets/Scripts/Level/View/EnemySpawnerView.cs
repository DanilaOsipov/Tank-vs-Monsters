using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class EnemySpawnerView : View<EnemySpawnerModel>
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyType _enemyType;
        private float _spawnDelay;

        public EnemyType EnemyType => _enemyType;

        public List<Transform> SpawnPoints => _spawnPoints;

        public event Action<EnemyType> OnReadyToSpawn = delegate(EnemyType enemyType) { };

        public override void Initialize(EnemySpawnerModel data)
        {
            _spawnDelay = data.Config.SpawnDelay;
        }
        
        public override void UpdateView(EnemySpawnerModel data)
        {
        }

        public void StartSpawnCoroutine()
        {
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);
                OnReadyToSpawn(_enemyType);
            }
        }
    }
}