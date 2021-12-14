using System.Linq;
using System.Threading.Tasks;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Command
{
    public class ShootCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        
        public ShootCommand(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }
        
        public async void Execute()
        {
            var weaponModel = _levelModel.PlayerModel.EquipedWeapon;
            if (weaponModel == null) return;
            if (weaponModel.State != WeaponState.ReadyToShoot) return;
            if (weaponModel.State == WeaponState.Reloading) return;
            weaponModel.State = WeaponState.Shooting;
            ExecuteShootLogic(weaponModel);
            if (weaponModel.Config.IsReloadable 
                && weaponModel.FiredShotsCount % weaponModel.Config.ShotsBeforeReload == 0)
            {
                weaponModel.State = WeaponState.Reloading;
                var reloadTime = weaponModel.Config.ReloadTime; 
                for (float t = 0; t < reloadTime; t += Time.deltaTime)
                {
                    weaponModel.ReloadingTimeLeft = reloadTime - t;
                    await Task.Yield();
                }
                weaponModel.ReloadingTimeLeft = null;
            }
            else
            {
                weaponModel.State = WeaponState.DelayingAfterShot;
                await Task.Delay(Mathf.RoundToInt(weaponModel.Config.DelayAfterShot * 1000.0f));
            }
            weaponModel.State = WeaponState.ReadyToShoot;
        }

        private void ExecuteShootLogic(WeaponModel weaponModel)
        {
            var projectilePoolModel = _levelModel.ProjectilePoolModels
                .FirstOrDefault(x => x.Config.ProjectileType == weaponModel.Config.ProjectileType);
            if (projectilePoolModel == null) return;
            var projectilePoolElementModel = projectilePoolModel.Elements
                .FirstOrDefault(x => !x.IsActive);
            if (projectilePoolElementModel == null) return;
            projectilePoolElementModel.Transform.position = weaponModel.Transform.position;
            projectilePoolElementModel.Transform.rotation = weaponModel.Transform.rotation;
            projectilePoolElementModel.IsActive = true;
        }
    }
}