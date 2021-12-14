using System;
using System.Threading.Tasks;
using Common;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ResourceManagement
{
    public class UnloadSceneCommand : ManageSceneResourceCommand
    {
        public event Action<string> OnSceneUnloaded = delegate(string sceneName) { }; 
        
        public UnloadSceneCommand(string sceneName) : base(sceneName)
        {
        }

        public override void Execute()
        {
            base.Execute();
            OnSceneUnloaded(_sceneName);
        }

        protected override AsyncOperation GetAsyncOperation(string sceneName)
        {
            return SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}