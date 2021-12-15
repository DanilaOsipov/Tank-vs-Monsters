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
        }
    }
}