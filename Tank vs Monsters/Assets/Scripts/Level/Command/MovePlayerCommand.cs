using Common;
using Level.Model;
using UnityEngine;

namespace Level.Command
{
    public class MovePlayerCommand : ICommand
    {
        private readonly Vector2 _moveVector;
        private readonly PlayerModel _playerModel;

        public MovePlayerCommand(PlayerModel playerModel, Vector2 moveVector)
        {
            _playerModel = playerModel;
            _moveVector = moveVector;
        }
        
        public void Execute()
        {
            _playerModel.CurrentInputVector = Vector2.SmoothDamp(_playerModel.CurrentInputVector,
                    _moveVector,
                    ref _playerModel.CurrentVelocity, 
                    _playerModel.Config.InputSmoothTime);

            var eulerAngles = _playerModel.Transform.rotation.eulerAngles;
            eulerAngles.z -= _playerModel.CurrentInputVector.x 
                             * _playerModel.Config.RotationSpeed * Time.deltaTime; 
            _playerModel.Transform.rotation = Quaternion.Euler(eulerAngles);

            if (_playerModel.CurrentInputVector.y >= 0)
            {
                _playerModel.Transform.position = _playerModel.Transform.position + _playerModel.Transform.up 
                    * (_playerModel.CurrentInputVector.y * _playerModel.Config.MovementSpeed * Time.deltaTime);
            }
        }
    }
}