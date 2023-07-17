using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Components.Platform;
using Models.Platform;
using Modules.App;
using UnityEngine;
using Random = System.Random;

namespace Modules.Platforms.Impl
{
    public sealed class PlatformsController : IPlatformsController
    {
        [Inject] public IEventDispatcher Dispatcher { get; set; }
        [Inject] public IAssetsController AssetsController { get; set; }

        private Pool<PlatformView> _pool;
        private Pool<PlatformModel> _modelPool;
        private PlatformView _platformPrefab;

        private Vector3Int _normalSize = new Vector3Int(1, 1, 1);
        private Vector3Int _bigSize = new Vector3Int(5, 1, 5);

        private int _probability = 15;
        Random rand = new Random();

        public int NormalPlatformCount => 50;

        [PostConstruct]
        private void PostConstruct()
        {
            _pool = new Pool<PlatformView>(CreatePlatform);
            _modelPool = new Pool<PlatformModel>(() => new PlatformModel(Vector3Int.zero, Vector3Int.zero));

            Dispatcher.AddListener(AppEvent.Loaded, OnAppLoaded);
        }

        [OnDestroy]
        private void OnDestroy()
        {
            Dispatcher.RemoveListener(AppEvent.Loaded, OnAppLoaded);
        }

        private void OnAppLoaded()
        {
            _platformPrefab = AssetsController.GetAsset<GameObject>(Assets.AssetBundle.Default, "Platform")
                .GetComponent<PlatformView>();
        }

        private PlatformView CreatePlatform()
        {
            var platform = Object.Instantiate(_platformPrefab).GetComponent<PlatformView>();
            platform.gameObject.SetActive(false);
            return platform;
        }

        public PlatformView GetNormalPlatform()
        {
            var platform = _pool.Take();
            platform.gameObject.SetActive(false);
            var model = _modelPool.Take();
            model.SetScale(_normalSize);

            platform.SetModel(model);

            return platform;
        }

        public PlatformView GetBigPlatform()
        {
            var platform = _pool.Take();
            platform.gameObject.SetActive(false);
            var model = _modelPool.Take();
            model.SetScale(_bigSize);

            platform.SetModel(model);

            return platform;
        }

        public bool RollGemActive()
        {
            var random = rand.Next(0, 100);
            var result = random < _probability;

            _probability += result ? -5 : 5;

            return result;
        }

        public void Release(PlatformView platform)
        {
            platform.gameObject.SetActive(false);
            
            platform.Model.Reset();
            platform.SetModel(null);
            _modelPool.Return(platform.Model);
            
            _pool.Return(platform);
        }

        public PlatformDirection NextDirection()
        {
            return EnumExtensions<PlatformDirection>.Random();
        }
    }
}