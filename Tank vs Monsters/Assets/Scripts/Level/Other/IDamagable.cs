namespace Level.Other
{
    public interface IDamagable
    {
        int Damage { get; }
        bool IsFriendlyToPlayer { get; }
    }
}