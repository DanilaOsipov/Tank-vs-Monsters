using Level.Config;
using Level.Other;

namespace Level.Model
{
    public class EnemyModel : EntityModel<EnemyConfig>, IHealableModel, IDefencableModel, IDamagerModel
    {
        public HealthModel HealthModel { get; }
        public DefenceModel DefenceModel { get; }
        public DamageModel DamageModel { get; }
        
        public EnemyModel(EnemyConfig config) : base(config)
        {
            HealthModel = new EnemyHealthModel(config.HealthEntity);
            DefenceModel = new EnemyDefenceModel(config.DefenceEntity);
            DamageModel = new EnemyDamageModel(config.DamageEntity);
        }
        
        public override string ToString() => $"{Config.Type}Enemy";
    }
}