using Level.Config;
using Level.Other;

namespace Level.Model
{
    public class ProjectileModel : EntityModel<ProjectileConfig>, IDamagerModel
    {
        public DamageModel DamageModel { get; }
        
        public ProjectileModel(ProjectileConfig config) : base(config)
        {
            DamageModel = new ProjectileDamageModel(config.DamageEntity);
        }
        
        public override string ToString() => $"{Config.Type}Projectile";
    }
}