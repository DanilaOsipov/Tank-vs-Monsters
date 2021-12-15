using Common;
using Level.Model;
using UnityEngine;

namespace Level.Command
{
    public class MovePlayerCommand : ICommand
    {
        private readonly PlayerModel _playerModel;

        public Vector2 MoveVector { get; set; }

        public MovePlayerCommand(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Execute()
        {
            _playerModel.CurrentInputVector = Vector2.SmoothDamp(_playerModel.CurrentInputVector,
                    MoveVector,
                    ref _playerModel.CurrentVelocity, 
                    _playerModel.Config.InputSmoothTime);

            var eulerAngles = _playerModel.Transform.rotation.eulerAngles;
            eulerAngles.z -= _playerModel.CurrentInputVector.x 
                             * _playerModel.Config.RotationSpeed * Time.deltaTime; 
            _playerModel.Transform.rotation = Quaternion.Euler(eulerAngles);
            
            _playerModel.Transform.position = _playerModel.Transform.position + _playerModel.Transform.up 
                * (_playerModel.CurrentInputVector.y * _playerModel.Config.MovementSpeed * Time.deltaTime);
        }
    }
}