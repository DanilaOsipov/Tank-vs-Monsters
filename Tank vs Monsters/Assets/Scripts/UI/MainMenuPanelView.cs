using Common;
using ResourceManagement;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuPanelView : UIPanelView<MainMenuPanelData>
    {
        [SerializeField] private Button _startButton;

        public override UIPanelType Type => UIPanelType.MainMenuPanel;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartButtonClickHandler);
        }

        private void OnStartButtonClickHandler()
        {
            Hide();
            var loadSceneCommand = new LoadSceneCommand(SceneNames.LEVEL_SCENE);
            loadSceneCommand.Execute();
        }

        protected override void UpdateView(MainMenuPanelData data)
        {
        }

        public override void Initialize(UIPanelData data)
        {
        }
    }
    
     public class MainMenuPanelData : UIPanelData
    {
    }
}