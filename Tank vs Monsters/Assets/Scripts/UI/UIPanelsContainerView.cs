using System.Collections.Generic;
using Common;
using UnityEngine;

namespace UI
{
    public class UIPanelsContainerView : MonoBehaviour
    {
        [SerializeField] private List<UIPanelView> _panels = new List<UIPanelView>();
        
        private static List<UIPanelView> _staticPanels;
        
        private void Awake()
        {
            _staticPanels = _panels;
        }

        public static void ShowPanel(UIPanelType type)
        {
            _staticPanels.Find(x => x.Type == type).Show();
        }

        public static void UpdatePanel(UIPanelType type, UIPanelData data)
        {
            _staticPanels.Find(x => x.Type == type).UpdateView(data);
        }

        public static void HidePanel(UIPanelType type)
        {
            _staticPanels.Find(x => x.Type == type).Hide();
        }
    }
}