using System.Threading.Tasks;
using Common;
using UI;
using UnityEngine;

namespace ResourceManagement
{
    public abstract class ManageSceneResourceCommand : ICommand
    {
        protected readonly string _sceneName;

        protected ManageSceneResourceCommand(string sceneName)
        {
            _sceneName = sceneName;
        }
        
        public virtual async void Execute()
        {
            UIPanelsContainerView.Instance.ShowPanel(UIPanelType.LoadingPanel);
            var asyncOperation = GetAsyncOperation(_sceneName);
            while (!asyncOperation.isDone)
            {
                var loadingPanelData = new LoadingPanelData(asyncOperation.progress);
                UIPanelsContainerView.Instance.UpdatePanel(UIPanelType.LoadingPanel, loadingPanelData);   
                await Task.Yield();
            }
            UIPanelsContainerView.Instance.HidePanel(UIPanelType.LoadingPanel);
        }
        
        protected abstract AsyncOperation GetAsyncOperation(string sceneName);
    }
}