using System;
using System.Collections.Generic;
using Common;
using Level.Config;
using Level.Model;
using ResourceManagement;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Level.View
{
    public abstract class ObjectPoolView<TModel, TConfig, TElementModel, TElementConfig, TElementView>
        : View<TModel>
        where TModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
        where TElementView : EntityView<TElementModel, TElementConfig>
        where TElementModel : EntityModel<TElementConfig>
        where TElementConfig : EntityConfig
        where TConfig : ObjectPoolConfig<TElementConfig>
    {
        public List<TElementView> Elements { get; private set; }

        public event Action<string, Collision2D> OnElementCollisionEnter 
            = delegate(string id, Collision2D collision) { };
        
        public override void Initialize(TModel data)
        {
            Elements = new List<TElementView>(data.Config.Size);
            var loadPrefabCommand = new LoadPrefabCommand(data.Config.ElementConfig.ViewPath);
            loadPrefabCommand.OnPrefabLoaded += delegate(Object obj) { OnPrefabLoadedHandler(obj, data); };
            loadPrefabCommand.Execute();
            for (var i = 0; i < data.Elements.Count; i++)
            {
                Elements[i].Initialize(data.Elements[i]);
                Elements[i].OnCollisionEnter += delegate(string id, Collision2D collision)
                {
                    OnElementCollisionEnter(id, collision);
                };
            }
        }

        private void OnPrefabLoadedHandler(Object obj, TModel objectPoolModel)
        {
            var instantiateObjectCommand = new InstantiateObjectCommand(obj);
            instantiateObjectCommand.OnObjectInstantiated += OnObjectInstantiatedHandler;
            for (var i = 0; i < objectPoolModel.Elements.Count; i++)
            {
                instantiateObjectCommand.Execute();
            }
        }

        private void OnObjectInstantiatedHandler(Object obj)
        {
            var elementView = obj.GetComponent<TElementView>();
            elementView.transform.SetParent(transform);
            elementView.transform.localScale = transform.localScale; 
            Elements.Add(elementView);
        }
    }
}