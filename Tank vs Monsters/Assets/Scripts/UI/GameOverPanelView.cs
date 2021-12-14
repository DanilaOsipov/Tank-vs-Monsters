using Common;
using ResourceManagement;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverPanelView : UIPanelView<LoadingPanelData>
    {
        [SerializeField] private Button _retryButton;
        
        public override UIPanelType Type => UIPanelType.GameOverPanel;
        
        private void Awake()
        {
            _retryButton.onClick.AddListener(OnRetryButtonClickHandler);
        }

        private void OnRetryButtonClickHandler()
        {
            Hide();
            var unloadSceneCommand = new UnloadSceneCommand(SceneNames.LEVEL_SCENE);
            unloadSceneCommand.OnSceneUnloaded += OnSceneUnloadedHandler;
            unloadSceneCommand.Execute();
        }

        private void OnSceneUnloadedHandler(string sceneName)
        {
            var loadSceneCommand = new LoadSceneCommand(SceneNames.LEVEL_SCENE);
            loadSceneCommand.Execute();
        }

        public override void Initialize(UIPanelData data)
        {
        }
        
        protected override void UpdateView(LoadingPanelData data)
        {
        }
    }
}