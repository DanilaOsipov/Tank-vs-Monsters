using System.Linq;
using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Command
{
    public class CheckEntityCollisionCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        private readonly string _id;
        private readonly Collision2D _collision;

        public CheckEntityCollisionCommand(LevelModel levelModel, string id, Collision2D collision)
        {
            _levelModel = levelModel;
            _id = id;
            _collision = collision;
        }
        
        public void Execute()
        {
            var entityModel = _levelModel.GetEntityModel(_id);
            if (entityModel is ProjectileModel projectileModel)
            {
                if (projectileModel.Config.Type == ProjectileType.Bullet)
                {
                    projectileModel.IsActive = false;
                    return;
                }
            }
            if (entityModel is not IHealableModel) return;
            var entityView = _collision.transform.GetComponent<IEntityView>();
            if (entityView == null) return;
            var collisionEntityModel = _levelModel.GetEntityModel(entityView.Id);
            if (collisionEntityModel is not IDamagerModel damagerModel) return;
            if (_levelModel.IsEntitiesFriendly(_id, collisionEntityModel.Id)) return;
            var dealDamageCommand
                = new DealDamageCommand(_levelModel, _id, damagerModel.DamageModel.Damage);
            dealDamageCommand.Execute();
        }
    }
}