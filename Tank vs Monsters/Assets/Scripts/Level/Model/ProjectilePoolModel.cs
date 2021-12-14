using Common;
using Level.Config;

namespace Level.Model
{
    public class ProjectilePoolModel : ObjectPoolModel<ProjectilePoolConfig, ProjectileModel, ProjectileConfig>
    {
        public ProjectilePoolModel(ProjectilePoolConfig config) : base(config)
        {
        }

        protected override ProjectileModel CreateElement(ProjectileConfig elementConfig)
            => new ProjectileModel(elementConfig);
    }
}