using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Config;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class PlayerView : EntityView<PlayerModel, PlayerConfig>
    {
        [SerializeField] private List<WeaponView> _weaponViews;

        public List<WeaponView> WeaponViews => _weaponViews;

        public override void Initialize(PlayerModel data)
        {
            data.OnEquipedWeaponChanged += EquipWeapon;
            EquipWeapon(data.EquipedWeapon.Config.Type);
        }

        private void EquipWeapon(WeaponType weaponType)
        {
            foreach (var weaponView in _weaponViews)
            {
                weaponView.gameObject.SetActive(false);
            }
            var equipedWeaponView = _weaponViews.FirstOrDefault(x => x.Type == weaponType);
            equipedWeaponView.gameObject.SetActive(true);
        }
    }
}