using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common;
using Level.Command;
using Level.Config;
using Level.Model;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Level.View
{
    public class LevelView : View<LevelModel>
    {
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private List<EnemyPoolView> _enemyPoolViews;
        [SerializeField] private List<ProjectilePoolView> _projectilePoolViews;
        [SerializeField] private List<EnemySpawnerView> _enemySpawnerViews;
        private LevelModel _levelModel;
        private Controls _controls;
        
        private void Awake()
        {
            _controls = new Controls();
            _controls.Main.Shoot.performed += OnPlayerShootHandler;
            _controls.Main.PreviousWeapon.performed += OnPlayerEquipPreviosWeaponHandler;
            _controls.Main.NextWeapon.performed += OnPlayerEquipNextWeaponHandler;
            _levelModel = new LevelModel(_levelConfig) {BoxCollider2D = GetComponent<BoxCollider2D>()};
            InitializePlayer();
            InitializeProjectilePools();
            InitializeEnemyPools();
            InitializeEnemySpawners();
            UIPanelsContainerView.Instance.ShowPanel(UIPanelType.PlayerInfoPanel);
            UIPanelsContainerView.Instance.ShowPanel(UIPanelType.ControlsTipsPanel);
        }

        private void OnDestroy()
        {
            _controls.Main.Shoot.performed -= OnPlayerShootHandler;
            _controls.Main.PreviousWeapon.performed -= OnPlayerEquipPreviosWeaponHandler;
            _controls.Main.NextWeapon.performed -= OnPlayerEquipNextWeaponHandler;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var handleLevelTriggerExitCommand 
                = new HandleLevelTriggerExitCommand(other, _levelModel);
            handleLevelTriggerExitCommand.Execute();
        }

        private void InitializePlayer()
        {
            _levelModel.PlayerModel.Transform = _playerView.transform;
            foreach (var weaponModel in _levelModel.PlayerModel.WeaponModels)
            {
                weaponModel.Transform = _playerView.WeaponViews
                    .FirstOrDefault(x => x.Type == weaponModel.Config.Type)
                    ?.transform;
            }
            _playerView.Initialize(_levelModel.PlayerModel);
            _playerView.OnCollisionEnter += delegate(string id, Collision2D collision)
            {
                var checkEntityCollisionCommand
                    = new CheckEntityCollisionCommand(_levelModel, id, collision);
                checkEntityCollisionCommand.Execute(); 
            };
        }

        private void InitializeEnemySpawners()
        {
            foreach (var spawnerModel in _levelModel.EnemySpawnerModels)
            {
                var spawnerView = _enemySpawnerViews
                    .FirstOrDefault(x => x.EnemyType == spawnerModel.Config.EnemyType);
                if (spawnerView == null) continue;
                spawnerModel.SpawnPoints = spawnerView.SpawnPoints;
                spawnerView.OnReadyToSpawn += delegate(EnemyType type)
                {
                    var spawnEnemyCommand = new SpawnEnemyCommand(type, _levelModel);
                    spawnEnemyCommand.Execute();
                };
                spawnerView.Initialize(spawnerModel);
                spawnerView.StartSpawnCoroutine();
            }
        }

        private void InitializeProjectilePools()
        {
            foreach (var projectilePoolModel in _levelModel.ProjectilePoolModels)
            {
                var projectilePoolView = _projectilePoolViews.FirstOrDefault(x 
                    => x.ProjectileType == projectilePoolModel.Config.ProjectileType);
                InitializeObjectPool<ProjectilePoolView, ProjectilePoolModel, ProjectilePoolConfig, 
                    ProjectileModel, ProjectileConfig, ProjectileView>(projectilePoolView, projectilePoolModel);
            }
        }
        
        private void InitializeEnemyPools()
        {
            foreach (var enemyPoolModel in _levelModel.EnemyPoolModels)
            {
                var enemyPoolView = _enemyPoolViews
                    .FirstOrDefault(x => x.EnemyType == enemyPoolModel.Config.EnemyType);
                InitializeObjectPool<EnemyPoolView, EnemyPoolModel, EnemyPoolConfig, EnemyModel,
                    EnemyConfig, EnemyView>(enemyPoolView, enemyPoolModel);
            }
        }

        private void InitializeObjectPool<TPoolView, TPoolModel, TConfig, TElementModel,
            TElementConfig, TElementView>(TPoolView poolView, TPoolModel poolModel)
            where TPoolView : ObjectPoolView<TPoolModel, TConfig, TElementModel, TElementConfig, TElementView>
            where TPoolModel : ObjectPoolModel<TConfig, TElementModel, TElementConfig>
            where TElementView : EntityView<TElementModel, TElementConfig>
            where TElementModel : EntityModel<TElementConfig>
            where TElementConfig : EntityConfig
            where TConfig : ObjectPoolConfig<TElementConfig>
        
        {
            poolView.Initialize(poolModel);
            foreach (var elementModel in poolModel.Elements)
            {
                elementModel.Transform = poolView.Elements
                    .FirstOrDefault(x => x.Id == elementModel.Id)?.transform;
            }
            poolView.OnElementCollisionEnter += (id, collision) =>
            {
                var checkEntityCollisionCommand
                    = new CheckEntityCollisionCommand(_levelModel, id, collision);
                checkEntityCollisionCommand.Execute();
            };
        }

        private void Update()
        {
            if (!_levelModel.IsUpdating) return;
            HandleInput();
            UpdateObjectPools();
            UpdatePlayerInfo();
        }

        private void UpdatePlayerInfo()
        {
            var updatePlayerInfoPanelCommand
                = new UpdatePlayerInfoPanelCommand(_levelModel.PlayerModel);
            updatePlayerInfoPanelCommand.Execute();
        }

        private void UpdateObjectPools()
        {
            foreach (var updateBulletPoolCommand in _levelModel.EnemyPoolModels
                .Select(objectPoolModel => new UpdateEnemyPoolCommand(objectPoolModel, _levelModel)))
            {
                updateBulletPoolCommand.Execute();
            }
            foreach (var updateProjectilePoolCommand in _levelModel.ProjectilePoolModels
                .Select(projectilePoolModel => new UpdateProjectilePoolCommand(projectilePoolModel)))
            {
                updateProjectilePoolCommand.Execute();
            }
        }
        
        private void HandleInput()
        {
            var playerModel = _levelModel.PlayerModel;
            var moveVector = _controls.Main.Move.ReadValue<Vector2>();
            var movePlayerCommand = new MovePlayerCommand(playerModel, moveVector);
            movePlayerCommand.Execute();
        }

        private void OnPlayerShootHandler(InputAction.CallbackContext context)
        {
            var shootCommand = new ShootCommand(_levelModel);
            shootCommand.Execute();
        }

        private void OnPlayerEquipPreviosWeaponHandler(InputAction.CallbackContext context)
        {
            var equipPreviousPlayerWeaponCommand = new EquipPreviousPlayerWeaponCommand(_levelModel.PlayerModel);
            equipPreviousPlayerWeaponCommand.Execute();
        }

        private void OnPlayerEquipNextWeaponHandler(InputAction.CallbackContext context)
        {
            var equipNextPlayerWeaponCommand = new EquipNextPlayerWeaponCommand(_levelModel.PlayerModel);
            equipNextPlayerWeaponCommand.Execute();
        }

        public override void UpdateView(LevelModel data)
        {
        }

        public override void Initialize(LevelModel data)
        {
        }
    }
}