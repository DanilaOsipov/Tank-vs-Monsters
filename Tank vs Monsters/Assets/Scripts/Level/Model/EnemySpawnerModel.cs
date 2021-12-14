using System.Collections.Generic;
using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class EnemySpawnerModel : Model<EnemySpawnerConfig>
    {
        public List<Transform> SpawnPoints { get; set; }
        
        public EnemySpawnerModel(EnemySpawnerConfig config) : base(config)
        {
        }
    }
}