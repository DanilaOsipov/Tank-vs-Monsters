using Common;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerInfoPanelView : UIPanelView<PlayerInfoPanelData>
    {
        [SerializeField] private TMP_Text _playerPosition;
        [SerializeField] private TMP_Text _playerRotation;
        [SerializeField] private TMP_Text _playerVelocity;
        [SerializeField] private TMP_Text _laserShots;
        [SerializeField] private TMP_Text _laserReloadingTimeLeft;
        
        public override UIPanelType Type => UIPanelType.PlayerInfoPanel;
        
        public override void Initialize(UIPanelData data)
        {
        }
        
        protected override void UpdateView(PlayerInfoPanelData data)
        {
            _playerPosition.text = "Position: " + data.PlayerPosition.ToString("0.00");
            _playerRotation.text = "Rotation: " + data.PlayerRotation.eulerAngles.z.ToString("0.00");
            _playerVelocity.text = "Velocity: " + data.PlayerVelocity.magnitude.ToString("0.00");
            if (data.LaserReloadingTimeLeft == null)
            {
                _laserReloadingTimeLeft.gameObject.SetActive(false);    
                _laserShots.text = string.Format($"Laser shots: {data.CurrentLaserShots} / {data.LaserShotsBeforeReload}");
                _laserShots.gameObject.SetActive(true);
            }
            else
            {
                _laserShots.gameObject.SetActive(false);
                _laserReloadingTimeLeft.text = "Reloading laser: " + data.LaserReloadingTimeLeft.Value.ToString("0.00");
                _laserReloadingTimeLeft.gameObject.SetActive(true);
            }
        }
    }

    public class PlayerInfoPanelData : UIPanelData
    {
        public Vector2 PlayerPosition { get; }
        public Quaternion PlayerRotation { get; }
        public Vector2 PlayerVelocity { get; }
        public int CurrentLaserShots { get; }
        public int LaserShotsBeforeReload { get; }
        public float? LaserReloadingTimeLeft { get; }

        public PlayerInfoPanelData(Vector2 playerPosition, Quaternion playerRotation,
            Vector2 playerVelocity, int currentLaserShots, int laserShotsBeforeReload,
            float? laserReloadingTimeLeft)
        {
            PlayerPosition = playerPosition;
            PlayerRotation = playerRotation;
            PlayerVelocity = playerVelocity;
            CurrentLaserShots = currentLaserShots;
            LaserShotsBeforeReload = laserShotsBeforeReload;
            LaserReloadingTimeLeft = laserReloadingTimeLeft;
        }
    }
}