using System.Collections.Generic;
using Common;
using Level.Config;
using UnityEngine;

namespace Level.Model
{
    public abstract class ObjectPoolModel<TConfig, TElementModel, TElementConfig> 
        : Model<TConfig>
        where TConfig : ObjectPoolConfig<TElementConfig>
        where TElementModel : EntityModel<TElementConfig>
        where TElementConfig : EntityConfig
    {
        public List<TElementModel> Elements { get; }
        
        protected ObjectPoolModel(TConfig config) : base(config)
        {
            Elements = new List<TElementModel>(config.Size);
            for (int i = 0; i < config.Size; i++)
            {
                var elementModel = CreateElement(config.ElementConfig);
                elementModel.Id = elementModel + "-" + i;
                Elements.Add(elementModel);
            }
        }

        protected abstract TElementModel CreateElement(TElementConfig elementConfig);
    }
}