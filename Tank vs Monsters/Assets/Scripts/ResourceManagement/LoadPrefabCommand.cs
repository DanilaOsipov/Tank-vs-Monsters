using System;
using Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResourceManagement
{
    public class LoadPrefabCommand : ICommand
    {
        private readonly string _prefabPath;

        public event Action<Object> OnPrefabLoaded = delegate(Object obj) { };  
        
        public LoadPrefabCommand(string prefabPath)
        {
            _prefabPath = prefabPath;
        }
        
        public void Execute()
        {
            var prefab = Resources.Load(_prefabPath);
            OnPrefabLoaded(prefab);
            // var instance = Object.Instantiate(prefab);
            // var poolElement = instance.GetComponent<IObjectPoolElementView>();
            // poolElement.Initialize(_elementModel);
            // _objectPool.Add(poolElement);
        }
    }
}