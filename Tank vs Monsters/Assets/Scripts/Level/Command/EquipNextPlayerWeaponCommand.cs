using Level.Model;

namespace Level.Command
{
    public class EquipNextPlayerWeaponCommand : EquipPlayerWeaponCommand
    {
        public EquipNextPlayerWeaponCommand(PlayerModel playerModel) : base(playerModel)
        {
        }

        protected override int GetWeaponToEquipIndex()
        {
            var idx = _playerModel.WeaponModels.IndexOf(_playerModel.EquipedWeapon);
            idx++;
            if (idx >= _playerModel.WeaponModels.Count)
            {
                idx = 0;
            }
            return idx;
        }
    }
}