using Common;
using Level.Model;
using UI;

namespace Level.Command
{
    public class CheckPlayerHealthCommand : ICommand
    {
        private readonly LevelModel _levelModel;

        public CheckPlayerHealthCommand(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }
        
        public void Execute()
        {
            if (_levelModel.PlayerModel.HealthModel.Health > 0) return;
            _levelModel.IsUpdating = false;
            UIPanelsContainerView.HidePanel(UIPanelType.PlayerInfoPanel);
            UIPanelsContainerView.HidePanel(UIPanelType.ControlsTipsPanel);
            UIPanelsContainerView.ShowPanel(UIPanelType.GameOverPanel);
        }
    }
}