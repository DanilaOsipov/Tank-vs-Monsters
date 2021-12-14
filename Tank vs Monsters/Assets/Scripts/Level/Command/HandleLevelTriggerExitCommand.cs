using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public class HandleLevelTriggerExitCommand : ICommand
    {
        private readonly Collider2D _collider;
        private readonly LevelModel _levelModel;

        public HandleLevelTriggerExitCommand(Collider2D collider, LevelModel levelModel)
        {
            _collider = collider;
            _levelModel = levelModel;
        }
        
        public void Execute()
        {
            var entityView = _collider.GetComponent<IEntityView>();
            switch (entityView)
            {
                case null:
                    return;
                case PlayerView:
                    TeleportPlayer();
                    return;
                default:
                    _levelModel.GetEntityModel(entityView.Id).IsActive = false;
                    break;
            }
        }

        private void TeleportPlayer()
        {
            var playerPos = _levelModel.PlayerModel.Transform.localPosition;
            var collider2D = _levelModel.BoxCollider2D;
            var sizeX = collider2D.size.x / 2;
            if (playerPos.x >= collider2D.transform.position.x + sizeX)
            {
                playerPos.x -= collider2D.size.x;
            }
            else if (playerPos.x <= collider2D.transform.position.x - sizeX)
            {
                playerPos.x += collider2D.size.x;
            }
            var sizeY = collider2D.size.y / 2;
            if (playerPos.y >= collider2D.transform.position.y + sizeY)
            {
                playerPos.y -= collider2D.size.y;
            }
            else if (playerPos.y <= collider2D.transform.position.y - sizeY)
            {
                playerPos.y += collider2D.size.y;
            }
            _levelModel.PlayerModel.Transform.localPosition = playerPos;
        }
    }
}