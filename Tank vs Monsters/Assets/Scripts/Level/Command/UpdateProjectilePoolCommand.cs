using Level.Config;
using Level.Model;

namespace Level.Command
{
    public class UpdateProjectilePoolCommand : UpdateObjectPoolCommand<ProjectilePoolModel,
        ProjectilePoolConfig, ProjectileModel, ProjectileConfig>
    {
        public UpdateProjectilePoolCommand(ProjectilePoolModel objectPoolModel) : base(objectPoolModel)
        {
        }
    }
}