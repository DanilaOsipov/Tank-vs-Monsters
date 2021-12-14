using System;
using Common;
using Object = UnityEngine.Object;

namespace ResourceManagement
{
    public class InstantiateObjectCommand : ICommand
    {
        private readonly Object _obj;

        public event Action<Object> OnObjectInstantiated = delegate(Object obj) { };  
        
        public InstantiateObjectCommand(Object obj)
        {
            _obj = obj;
        }
        
        public void Execute()
        {
            var instance = Object.Instantiate(_obj);
            OnObjectInstantiated(instance);
        }
    }
}