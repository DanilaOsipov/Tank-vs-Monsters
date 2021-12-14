using System;
using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public class WeaponModel : Model<WeaponConfig>
    {
        private WeaponState _state;
        
        public Transform Transform { get; set; }

        public WeaponState State
        {
            get => _state;
            set
            {
                _state = value;
                if (_state == WeaponState.Shooting) FiredShotsCount++;
                OnStateChanged(_state);
            }
        }

        public int FiredShotsCount { get; private set; }
        
        public float? ReloadingTimeLeft { get; set; }

        public event Action<WeaponState> OnStateChanged = delegate { };

        public WeaponModel(WeaponConfig config) : base(config)
        {
        }
    }
}