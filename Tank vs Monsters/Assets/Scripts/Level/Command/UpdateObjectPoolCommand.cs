using System.Linq;
using Common;
using Level.Config;
using Level.Model;
using Level.Other;
using Level.View;
using UnityEngine;

namespace Level.Command
{
    public abstract class UpdateObjectPoolCommand<TObjectPoolModel, TConfig, TElementModel, TElementConfig>
        : ICommand
        where TObjectPoolModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TConfig : ObjectPoolConfig<TElementConfig>
        where TElementModel : EntityModel<TElementConfig>
        where TElementConfig : EntityConfig
    {
        protected readonly TObjectPoolModel _objectPoolModel;

        protected UpdateObjectPoolCommand(TObjectPoolModel objectPoolModel)
        {
            _objectPoolModel = objectPoolModel;
        }

        public virtual void Execute()
        {
            foreach (var elementModel in _objectPoolModel.Elements
                .Where(elementModel => elementModel.IsActive))
            {
                elementModel.Transform.position += elementModel.Transform
                    .up * (elementModel.Config.MovementSpeed * Time.deltaTime);
            }
        }
    }
}