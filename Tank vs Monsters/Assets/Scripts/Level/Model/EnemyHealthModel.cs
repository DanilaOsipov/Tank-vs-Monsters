using System;

namespace Level.Model
{
    public class EnemyHealthModel : HealthModel
    {
        public EnemyHealthModel(HealthEntity healthEntity) : base(healthEntity)
        {
        }
    }

    [Serializable]
    public class EnemyHealthEntity : HealthEntity
    {
    }
}