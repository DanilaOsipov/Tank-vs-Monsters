using System;
using Common;
using Level.Config;
using Level.Other;
using UnityEngine;

namespace Level.Model
{
    public abstract class EntityModel<TConfig> : Model<TConfig>, IEntityModel
        where TConfig : EntityConfig
    {
        private bool _isActive;
        
        public string Id { get; set; }
        
        public Transform Transform { get; set; }

        EntityConfig IEntityModel.Config => Config;
        
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnIsActiveChanged(_isActive);
            }
        }
        
        public event Action<bool> OnIsActiveChanged = delegate(bool isActive) { };

        protected EntityModel(TConfig config) : base(config)
        {
        }
    }
}