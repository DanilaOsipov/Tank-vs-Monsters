using UnityEngine;

namespace Level.Config
{
    public abstract class EntityConfig : Common.Config
    {
        [SerializeField] private float _movementSpeed = 10.0f;
        [SerializeField] private string _viewPath;

        public float MovementSpeed => _movementSpeed;

        public string ViewPath => _viewPath;
    }
}