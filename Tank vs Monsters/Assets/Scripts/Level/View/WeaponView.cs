using Common;
using Level.Model;
using UnityEngine;

namespace Level.View
{
    public class WeaponView : View<WeaponModel>
    {
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private WeaponStateView _shootingStateView; 
    
        public WeaponType Type => _weaponType;

        public override void UpdateView(WeaponModel data)
        {
        }

        public override void Initialize(WeaponModel data)
        {
        }

        public void ShowState(WeaponState state)
        {
            if (state == WeaponState.Shooting)
            {
                if (_shootingStateView != null) _shootingStateView.Show();
            }
        }
    }
}