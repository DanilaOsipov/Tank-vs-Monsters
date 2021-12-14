using Common;

namespace UI
{
    public class ControlsTipsPanelView : UIPanelView<ControlsTipsPanelData>
    {
        public override UIPanelType Type => UIPanelType.ControlsTipsPanel;
        
        public override void Initialize(UIPanelData data)
        {
        }
        
        protected override void UpdateView(ControlsTipsPanelData data)
        {
        }
    }

    public class ControlsTipsPanelData : UIPanelData
    {
    }
}