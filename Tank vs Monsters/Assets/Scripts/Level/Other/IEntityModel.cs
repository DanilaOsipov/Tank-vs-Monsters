using Level.Config;

namespace Level.Other
{
    public interface IEntityModel : IEntity
    {
        EntityConfig Config { get; }
        bool IsActive { get; set; }
    }
}