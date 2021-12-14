using Common;
using Level.Model;

namespace Level.Command
{
    public abstract class EquipPlayerWeaponCommand : ICommand
    {
        protected readonly PlayerModel _playerModel;

        protected EquipPlayerWeaponCommand(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Execute()
        {
            _playerModel.EquipedWeapon = _playerModel.WeaponModels[GetWeaponToEquipIndex()];
        }

        protected abstract int GetWeaponToEquipIndex();
    }
}