using System.Linq;
using Common;
using Level.Model;
using UI;
using UnityEngine;

namespace Level.Command
{
    public class UpdatePlayerInfoPanelCommand : ICommand
    {
        private readonly PlayerModel _playerModel;

        public UpdatePlayerInfoPanelCommand(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }
        
        public void Execute()
        {
            var weaponModel = _playerModel.WeaponModels
                .FirstOrDefault(x => x.Config.Type == WeaponType.LaserGun);
            var shotsBeforeReload = weaponModel.Config.ShotsBeforeReload;
            var data = new PlayerInfoPanelData(_playerModel.Transform.position,
                _playerModel.Transform.rotation,
                _playerModel.CurrentVelocity,
                shotsBeforeReload - weaponModel.FiredShotsCount % shotsBeforeReload,
                shotsBeforeReload,
                weaponModel.ReloadingTimeLeft);
            UIPanelsContainerView.Instance.UpdatePanel(UIPanelType.PlayerInfoPanel, data);
        }
    }
}