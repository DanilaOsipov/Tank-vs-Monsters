using System;

namespace Level.Model
{
    public class ProjectileDamageModel : DamageModel
    {
        public ProjectileDamageModel(DamageEntity damageEntity) : base(damageEntity)
        {
        }
    }

    [Serializable]
    public class ProjectileDamageEntity : DamageEntity
    {
    }
}