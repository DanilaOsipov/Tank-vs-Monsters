using System;
using UnityEngine;

namespace Level.Model
{
    public abstract class DamageModel : Common.Model
    {
        public int Damage { get; }

        protected DamageModel(DamageEntity damageEntity)
        {
            Damage = damageEntity.Damage;
        }
    }

    [Serializable]
    public abstract class DamageEntity
    {
        [SerializeField] private int _damage;

        public int Damage => _damage;
    }
}