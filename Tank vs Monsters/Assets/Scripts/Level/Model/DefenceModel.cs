using System;
using UnityEngine;

namespace Level.Model
{
    public abstract class DefenceModel : Common.Model
    {
        public float Defence { get; }
        
        protected DefenceModel(DefenceEntity defenceEntity)
        {
            Defence = defenceEntity.Defence;
        }
    }

    [Serializable]
    public abstract class DefenceEntity
    {
        [SerializeField, Range(0, 1)] private float _defence;

        public float Defence => _defence;
    }
}