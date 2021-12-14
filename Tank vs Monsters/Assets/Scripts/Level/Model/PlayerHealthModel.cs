using System;

namespace Level.Model
{
    public class PlayerHealthModel : HealthModel
    {
        public PlayerHealthModel(HealthEntity healthEntity) : base(healthEntity)
        {
        }
    }

    [Serializable]
    public class PlayerHealthEntity : HealthEntity
    {
    }
}