using System;

namespace Level.Model
{
    public class EnemyDamageModel : DamageModel
    {
        public EnemyDamageModel(DamageEntity damageEntity) : base(damageEntity)
        {
        }
    }

    [Serializable]
    public class EnemyDamageEntity : DamageEntity
    {
    }
}