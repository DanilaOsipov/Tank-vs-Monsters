using System;
using System.Threading.Tasks;
using Common;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ResourceManagement
{
    public class LoadSceneCommand : ManageSceneResourceCommand
    {
        public event Action<string> OnSceneLoaded = delegate(string sceneName) { }; 
        
        public LoadSceneCommand(string sceneName) : base(sceneName)
        {
        }

        public override void Execute()
        {
            base.Execute();
            OnSceneLoaded(_sceneName);
        }

        protected override AsyncOperation GetAsyncOperation(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }
}