using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Assets;
using Components.Character;
using Components.Platform;
using Models.Character;
using Modules.Repository;
using UnityEngine;
using AssetBundle = Modules.Assets.AssetBundle;

namespace Modules.Character.Impl
{
    public sealed class CharacterController : ICharacterController
    {
        private const string SkinUnlockedFileName = "unlockedSkins.json";
        
        [Inject] public IEventDispatcher Dispatcher { get; set; }
        [Inject] public IAssetsController AssetsController { get; set; }
        [Inject] public IRepositoryController RepositoryController { get; set; }
        
        private GameObject _character;
        private SkinData _skinData;
        private CharacterSkinsScriptableObject _skinsScriptableObject;
        private IReadOnlyList<CharacterSkinData> _skinsData;

        public Transform CharacterTransform { get; private set; }
        public int CurrentSkin => _skinData.CurrentSkin;

        [PostConstruct]
        private void PostConstruct()
        {
            Dispatcher.AddListener(PlatformEvents.StartPlatformCreated, OnStartPlatformCreated);
            
            Dispatcher.AddListener(AssetsEvent.BundleLoadingSuccess, OnBundleLoaded);
        }
        
        [OnDestroy]
        private void OnDestroy()
        {
            Dispatcher.RemoveListener(PlatformEvents.StartPlatformCreated, OnStartPlatformCreated);
            RepositoryController.Save(_skinData, SkinUnlockedFileName);
        }

        public void SetSkin(int skin)
        {
            if(!_skinData.UnlockedSkinsArray.Contains(skin))
                return;
            _skinData.CurrentSkin = skin;
            Dispatcher.Dispatch(CharacterEvents.SkinChanged, skin);
        }
        
        public bool UnlockSkin(int skin)
        {
            if (_skinData.UnlockedSkinsArray.Contains(skin))
                return false;
            
            _skinData.UnlockedSkinsArray.Add(skin);
            return true;
        }
        
        public bool IsSkinUnlocked(int i)
        {
            return _skinData.UnlockedSkinsArray.Contains(i);
        }
        
        public IReadOnlyList<CharacterSkinData> GetSkins()
        {
            return _skinsData ??= new List<CharacterSkinData>(_skinsScriptableObject.Skins);
        }

        private void OnStartPlatformCreated()
        {
            if (_character == null)
            {
                var playerAsset = AssetsController.GetAsset<GameObject>(AssetBundle.Default, "Player");
                _character = Object.Instantiate(playerAsset, Vector3.up, Quaternion.identity);
                CharacterTransform = _character.transform;
                Dispatcher.Dispatch(CharacterEvents.CharacterCreated);
                return;
            }

            Dispatcher.Dispatch(CharacterEvents.ResetCharacter);
        }

        private void OnBundleLoaded(AssetBundleInfo info)
        {
            if(info != AssetBundle.Default)
                return;
            
            _skinsScriptableObject = AssetsController.GetAsset<CharacterSkinsScriptableObject>(AssetBundle.Default,"CharacterSkins");
            _skinData = RepositoryController.LoadOrCreate<SkinData>(SkinUnlockedFileName, out var created);
            if (created)
            {
                _skinData.UnlockedSkinsArray = new List<int>(_skinsScriptableObject.Skins.Count);
                _skinData.UnlockedSkinsArray.Add(0);
                _skinData.CurrentSkin = 0;
            }
            
            Dispatcher.RemoveListener(AssetsEvent.BundleLoadingSuccess, OnBundleLoaded);
        }
    }
}