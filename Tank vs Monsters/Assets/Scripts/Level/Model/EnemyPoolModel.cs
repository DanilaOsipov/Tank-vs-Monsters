using Common;
using Level.Config;

namespace Level.Model
{
    public class EnemyPoolModel : ObjectPoolModel<EnemyPoolConfig, EnemyModel, EnemyConfig>
    {
        public EnemyPoolModel(EnemyPoolConfig config) : base(config)
        {
        }

        protected override EnemyModel CreateElement(EnemyConfig elementConfig) => new EnemyModel(elementConfig);
    }
}