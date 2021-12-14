using System;

namespace Level.Model
{
    public class EnemyDefenceModel : DefenceModel
    {
        public EnemyDefenceModel(DefenceEntity defenceEntity) : base(defenceEntity)
        {
        }
    }

    [Serializable]
    public class EnemyDefenceEntity : DefenceEntity
    {
    }
}