using Common;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class WeaponView : View<WeaponModel>
    {
        [SerializeField] private WeaponType _weaponType;

        public WeaponType Type => _weaponType;

        public override void Initialize(WeaponModel data)
        {
        }
    }
}