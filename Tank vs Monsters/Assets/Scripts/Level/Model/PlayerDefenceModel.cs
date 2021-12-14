using System;

namespace Level.Model
{
    public class PlayerDefenceModel : DefenceModel
    {
        public PlayerDefenceModel(DefenceEntity defenceEntity) : base(defenceEntity)
        {
        }
    }

    [Serializable]
    public class PlayerDefenceEntity : DefenceEntity
    {
    }
}