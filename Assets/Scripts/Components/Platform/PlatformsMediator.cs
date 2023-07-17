using System;
using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Modules.Async;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Components.Character;
using Components.Gem;
using Models.Platform;
using Modules.App;
using Modules.Platforms;
using Modules.Platforms.Impl;
using UnityEngine;
using Screen = Modules.Screens.Screen;

namespace Components.Platform
{
    public sealed class PlatformsMediator : Mediator
    {
        [Inject] public PlatformsView View { get; set; }
        [Inject] public IPlatformsController PlatformsController { get; set; }
        [Inject] public IAsyncResolver AsyncResolver { get; set; }
        [Inject] public IEventMap EventMap { get; set; }

        private Queue<PlatformView> _platformsQueue;
        private PlatformView _lastPlatform;
        private int _platformsPassed;
        
        private Dictionary<PlatformView, int> _inProgressOfRemoving = new Dictionary<PlatformView, int>();

        private Dictionary<GemView, PlatformView> _gemsPlatforms = new Dictionary<GemView, PlatformView>();

        [PostConstruct]
        public void PostConstruct()
        {
            _platformsQueue = new Queue<PlatformView>(PlatformsController.NormalPlatformCount + 10);
            EventMap.MapOnce(AppEvent.Loaded, OnLoaded);
            EventMap.Map(CharacterEvents.CharacterEnteredPlatform, OnCharacterEnteredPlatform);
            EventMap.Map(CharacterEvents.CharacterCollectedGem, OnCharacterCollectedGem);
        }

        private void OnCharacterCollectedGem(GemView view)
        {
            var platform = _gemsPlatforms[view];
            platform.SetGemActive(false);
            _gemsPlatforms.Remove(view);
        }

        private void OnCharacterEnteredPlatform()
        {
            _platformsPassed++;
            if (_platformsPassed > 3)
            {
                _platformsPassed--;
                var platform = _platformsQueue.Dequeue();
                platform.SetKinematic(false);
                _inProgressOfRemoving.Add(platform, AsyncResolver.DelayedCall(RemovePlatform, platform, 1.5f));
            }

            GeneratePlatforms(1);
        }

        private void OnLoaded()
        {
            EventMap.Map(ScreenEvent.Shown, OnScreenShown);
            _lastPlatform = null;
            CreateStartPlatform();
            GeneratePlatforms(PlatformsController.NormalPlatformCount);
        }

        private void OnScreenShown(ScreenBase obj)
        {
            if (obj != Screen.MainScreen)
                return;

            _platformsPassed = 0;
            _gemsPlatforms.Clear();
            _lastPlatform = null;
            
            if (_inProgressOfRemoving.Count > 0)
            {
                foreach (var pair in _inProgressOfRemoving)
                {
                    AsyncResolver.CancelCall(pair.Value);
                    pair.Key.SetKinematic(true);
                    _gemsPlatforms.Remove(pair.Key.Gem);
                    PlatformsController.Release(pair.Key);
                }
            }
            _inProgressOfRemoving.Clear();

            while (_platformsQueue.Count > 0)
            {
                var platform = _platformsQueue.Dequeue();
                platform.gameObject.SetActive(false);
                PlatformsController.Release(platform);
            }

            CreateStartPlatform();
            GeneratePlatforms(PlatformsController.NormalPlatformCount);
        }

        private void CreateStartPlatform()
        {
            var platform = PlatformsController.GetBigPlatform();
            platform.SetGemActive(false);
            platform.transform.SetParent(View.transform);
            platform.Model.SetPosition(Vector3Int.zero);
            platform.UpdateByModel();

            _platformsQueue.Enqueue(platform);
            _lastPlatform = platform;

            platform.gameObject.SetActive(true);

            EventMap.Dispatch(PlatformEvents.StartPlatformCreated);
        }

        private void GeneratePlatforms(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var platform = PlatformsController.GetNormalPlatform();
                platform.transform.SetParent(View.transform);
                
                platform.Model.SetPosition(CalculateNextPosition(PlatformsController.NextDirection(),
                    platform.Model.Scale));
                platform.UpdateByModel();
                _lastPlatform = platform;
                
                platform.gameObject.SetActive(true);

                var gemActive = PlatformsController.RollGemActive();
                platform.SetGemActive(gemActive);
                if (gemActive)
                    _gemsPlatforms.Add(platform.Gem, platform);

                
                _platformsQueue.Enqueue(platform);
            }
        }

        private Vector3Int CalculateNextPosition(PlatformDirection direction, Vector3Int newPlatformScale)
        {
            return direction switch
            {
                PlatformDirection.Left => new Vector3Int(
                    _lastPlatform.Model.Position.x + _lastPlatform.Model.Scale.x + newPlatformScale.x, 0,
                    _lastPlatform.Model.Position.z + _lastPlatform.Model.Scale.z - newPlatformScale.z),

                PlatformDirection.Right => new Vector3Int(
                    _lastPlatform.Model.Position.x + _lastPlatform.Model.Scale.x - newPlatformScale.x, 0,
                    _lastPlatform.Model.Position.z + _lastPlatform.Model.Scale.z + newPlatformScale.z),

                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }

        private void RemovePlatform(PlatformView platform)
        {
            platform.SetKinematic(true);
            PlatformsController.Release(platform);
            _inProgressOfRemoving.Remove(platform);
            _gemsPlatforms.Remove(platform.Gem);
        }
    }
}