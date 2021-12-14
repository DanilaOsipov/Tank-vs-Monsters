using System;
using Common;
using UnityEngine;

namespace Level.Model
{
    public abstract class HealthModel : Common.Model
    {
        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnHealthChanged(_health);
            }
        }

        public event Action<int> OnHealthChanged = delegate(int health) { }; 

        protected HealthModel(HealthEntity healthEntity)
        {
            _health = healthEntity.Health;
        }
    }

    [Serializable]
    public abstract class HealthEntity
    {
        [SerializeField] private int _health;

        public int Health => _health;
    }
}