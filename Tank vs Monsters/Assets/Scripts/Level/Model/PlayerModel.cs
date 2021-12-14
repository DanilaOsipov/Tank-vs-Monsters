using System.Collections.Generic;
using System.Linq;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public class PlayerModel : EntityModel<PlayerConfig>, IHealableModel, IDefencableModel
    {
        private WeaponModel _equipedWeapon;
        public Vector2 CurrentInputVector;
        public Vector2 CurrentVelocity;

        public List<WeaponModel> WeaponModels { get; } = new List<WeaponModel>();

        public WeaponModel EquipedWeapon
        {
            get => _equipedWeapon;
            set
            {
                _equipedWeapon = value;
            }
        }

        public HealthModel HealthModel { get; }

        public DefenceModel DefenceModel { get; } 
        
        public PlayerModel(PlayerConfig config) : base(config)
        {
            foreach (var weaponConfig in config.WeaponConfigs)
            {
                WeaponModels.Add(new WeaponModel(weaponConfig));
            }
            EquipedWeapon = WeaponModels.FirstOrDefault();
            HealthModel = new PlayerHealthModel(config.HealthEntity);
            DefenceModel = new PlayerDefenceModel(config.DefenceEntity);
            IsActive = true;
        }
    }
}