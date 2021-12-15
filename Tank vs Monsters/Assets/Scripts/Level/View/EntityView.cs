using System;
using Level.Config;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.View
{
    public abstract class EntityView<TModel, TConfig> : Common.View<TModel>, IEntityView
        where TModel : EntityModel<TConfig>
        where TConfig : EntityConfig
    {
        public string Id { get; private set; }

        public event Action<string, Collision2D> OnCollisionEnter 
            = delegate(string id, Collision2D collision) { };
        
        public override void Initialize(TModel data)
        {
            Id = data.Id;
            data.OnIsActiveChanged += OnIsActiveChangedHandler;
            gameObject.SetActive(data.IsActive);
        }

        protected virtual void OnIsActiveChangedHandler(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter(Id, other);
        }
    }
}