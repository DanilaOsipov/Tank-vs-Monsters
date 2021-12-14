using Common;
using Level.Other;
using UnityEngine;

namespace Level.Config
{
    public abstract class ObjectPoolConfig<TElementConfig> : Common.Config
        where TElementConfig : EntityConfig
    {
        [SerializeField] private int _size = 20;
        [SerializeField] private TElementConfig  _elementConfig;
        
        public int Size => _size;

        public TElementConfig  ElementConfig => _elementConfig;
    }
}