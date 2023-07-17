using System.Collections.Generic;
using System.Linq;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Main
{
    [Mediator(typeof(SkinsScreenMediator))]
    public sealed class SkinsScreenView : UnityViewDispatcher
    {
        public readonly Event OnCloseButtonClick = new Event(typeof(SettingsScreenView), nameof(OnCloseButtonClick));
        public readonly Event<SkinItemView> OnApplyButtonClick = new Event<SkinItemView>(typeof(SettingsScreenView), nameof(OnApplyButtonClick));
        public readonly Event<SkinItemView> OnUnlockButtonClick = new Event<SkinItemView>(typeof(SettingsScreenView), nameof(OnUnlockButtonClick));

        [SerializeField] private Button _closeButton;
        
        [SerializeField] private TMP_Text _gemsText;
        [SerializeField] private SkinItemView _skinItemPrefab;
        [SerializeField] private Transform _skinItemContainer;

        private HashSet<SkinItemView> _skinItems = new HashSet<SkinItemView>();

        [Start]
        public void OnStart()
        {
            BindUnityEvent(_closeButton.onClick, OnCloseButtonClick);
        }

        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }
        
        public void SetGems(int gems)
        {
            _gemsText.text = gems.ToString();
        }
        
        public void AddSkinItem(int index, int price, Color color, bool isUnlocked, bool isApplied)
        {
            var skinItem = Instantiate(_skinItemPrefab, _skinItemContainer);
            skinItem.gameObject.SetActive(false);
            
            skinItem.SetData(index, price, color, isUnlocked, isApplied);
            skinItem.gameObject.SetActive(true);
            
            _skinItems.Add(skinItem);
            
            BindUnityEvent(skinItem.OnApplyButtonClick, OnApplyButtonClick, skinItem);
            BindUnityEvent(skinItem.OnUnlockButtonClick, OnUnlockButtonClick, skinItem);
        }

        public void UpdateItemView(int index, int price, Color color, bool isUnlocked, bool isApplied)
        {
            var skinItemView = _skinItems.FirstOrDefault(x => x.SkinIndex == index);
            if(skinItemView == null)
                return;
            skinItemView.SetData(index, price, color, isUnlocked, isApplied);
        }
    }
}