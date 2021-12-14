using Common;
using Level.Model;
using Level.Other;

namespace Level.Command
{
    public class DealDamageCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        private readonly string _entityId;
        private readonly int _damage;

        public DealDamageCommand(LevelModel levelModel, string entityId, int damage)
        {
            _levelModel = levelModel;
            _entityId = entityId;
            _damage = damage;
        }

        public void Execute()
        {
            var entityModel = _levelModel.GetEntityModel(_entityId);
            var healableModel = entityModel as IHealableModel;
            var defence = 1.0f;
            if (entityModel is IDefencableModel defencableModel)
            {
                defence = defencableModel.DefenceModel.Defence;
            }
            healableModel.HealthModel.Health -= (int)(_damage * defence);
            // if (_entityType != EntityType.Player)
            // {
            //     var objectPoolModel = _levelModel.ObjectPoolModels
            //         .FirstOrDefault(x => x.ElementType == _entityType);
            //     var elementModel = objectPoolModel.Elements
            //         .FirstOrDefault(x => x.Id == _entityId);
            //     if (elementModel is not IHealableModel healable) return;
            //     healable.Health += _damage;
            //     if (healable.Health > 0) return;
            //     healable.Health = ((IHealableModel)elementModel.Config).Health;
            //     elementModel.IsActive = false;
            //     elementModel.CallUpdateMethod();
            //
            //     if (elementModel.Type == EntityType.BigAsteroid)
            //     {
            //         ReactOnBigAsteroidDestroy(elementModel);
            //     }
            // }
            // else
            // {
            //     _levelModel.PlayerModel.Health += _damage;
            //     _levelModel.PlayerModel.CallUpdateMethod();
            //     if (_levelModel.PlayerModel.Health > 0) return;
            //     _levelModel.IsUpdating = false;
            //     UIPanelsContainerView.Instance.HidePanel(UIPanelType.PlayerInfoPanel);
            //     UIPanelsContainerView.Instance.HidePanel(UIPanelType.ControlsTipsPanel);
            //     UIPanelsContainerView.Instance.ShowPanel(UIPanelType.GameOverPanel);
            // }
        }
    }
}