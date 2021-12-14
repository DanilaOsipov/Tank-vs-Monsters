using Level.Model;

namespace Level.Command
{
    public class EquipPreviousPlayerWeaponCommand : EquipPlayerWeaponCommand
    {
        public EquipPreviousPlayerWeaponCommand(PlayerModel playerModel) : base(playerModel)
        {
        }

        protected override int GetWeaponToEquipIndex()
        {
            var idx = _playerModel.WeaponModels.IndexOf(_playerModel.EquipedWeapon);
            idx--;
            if (idx < 0)
            {
                idx = _playerModel.WeaponModels.Count - 1;
            }
            return idx;
        }
    }
}