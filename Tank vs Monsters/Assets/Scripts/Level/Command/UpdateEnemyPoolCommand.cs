using System.Linq;
using Level.Config;
using Level.Model;

namespace Level.Command
{
    public class UpdateEnemyPoolCommand : UpdateObjectPoolCommand<EnemyPoolModel, EnemyPoolConfig,
        EnemyModel,EnemyConfig>
    {
        private readonly LevelModel _levelModel;

        public UpdateEnemyPoolCommand(EnemyPoolModel objectPoolModel, LevelModel levelModel)
            : base(objectPoolModel)
        {
            _levelModel = levelModel;
        }

        public override void Execute()
        {
            foreach (var elementModel in _objectPoolModel.Elements
                .Where(elementModel => elementModel.IsActive))
            {
                elementModel.Transform.up = _levelModel.PlayerModel.Transform.position
                                            - elementModel.Transform.position;
            }
            base.Execute();
        }
    }
}