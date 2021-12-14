using System.Collections.Generic;
using Common;
using UnityEngine;

namespace UI
{
    public class UIPanelsContainerView : MonoBehaviour
    {
        [SerializeField] private List<UIPanelView> _panels = new List<UIPanelView>();

        public static UIPanelsContainerView Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
        }

        public bool IsPanelExits(UIPanelType type)
        {
            return _panels.Find(x => x.Type == type) != null;
        }
        
        public void ShowPanel(UIPanelType type)
        {
            _panels.Find(x => x.Type == type).Show();
        }

        public void UpdatePanel(UIPanelType type, UIPanelData data)
        {
            _panels.Find(x => x.Type == type).UpdateView(data);
        }

        public void PlacePanel(UIPanelView view)
        {
            view.Transform.SetParent(transform);
            view.Transform.localPosition = Vector3.zero;
            view.Transform.localScale = Vector3.one;
            view.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            _panels.Add(view);
        }

        public void HidePanel(UIPanelType type)
        {
            _panels.Find(x => x.Type == type).Hide();
        }
    }
}