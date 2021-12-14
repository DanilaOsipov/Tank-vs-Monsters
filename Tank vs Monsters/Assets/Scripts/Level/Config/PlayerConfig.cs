using System.Collections.Generic;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/PlayerConfig")]
    public class PlayerConfig : EntityConfig, IHealableConfig, IDefencableConfig
    {
        [SerializeField] private float _inputSmoothTime = 0.5f;
        [SerializeField] private float _rotationSpeed = 240.0f;
        [SerializeField] private List<WeaponConfig> _weaponConfigs;
        [SerializeField] private PlayerHealthEntity _healthEntity;
        [SerializeField] private PlayerDefenceEntity _defenceEntity;
        
        public float InputSmoothTime => _inputSmoothTime;

        public float RotationSpeed => _rotationSpeed;

        public List<WeaponConfig> WeaponConfigs => _weaponConfigs;

        public HealthEntity HealthEntity => _healthEntity;
        
        public DefenceEntity DefenceEntity => _defenceEntity;
    }
}