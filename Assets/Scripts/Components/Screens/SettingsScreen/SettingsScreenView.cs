using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using UnityEngine;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Main
{
    [Mediator(typeof(SettingsScreenMediator))]
    public sealed class SettingsScreenView : UnityViewDispatcher
    {
        public readonly Event OnCloseButtonClick = new Event(typeof(SettingsScreenView), nameof(OnCloseButtonClick));
        public readonly Event<bool> OnSoundButtonClick = new Event<bool>(typeof(SettingsScreenView), nameof(OnSoundButtonClick));
        public readonly Event<bool> OnAutoButtonClick = new Event<bool>(typeof(SettingsScreenView), nameof(OnAutoButtonClick));

        [SerializeField] private Button _closeButton;
        
        [SerializeField] private Button _soundOnButton;
        [SerializeField] private Button _soundOffButton;
        [SerializeField] private Button _autoOnButton;
        [SerializeField] private Button _autoOffButton;

        [Start]
        public void OnStart()
        {
            BindUnityEvent(_closeButton.onClick, OnCloseButtonClick);
            
            BindUnityEvent(_soundOnButton.onClick, OnSoundButtonClick, false);
            BindUnityEvent(_soundOffButton.onClick, OnSoundButtonClick, true);
            
            BindUnityEvent(_autoOnButton.onClick, OnAutoButtonClick, false);
            BindUnityEvent(_autoOffButton.onClick, OnAutoButtonClick, true);
        }

        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }
        
        public void SetSoundButton(bool isOn)
        {
            _soundOnButton.gameObject.SetActive(isOn);
            _soundOffButton.gameObject.SetActive(!isOn);
        }
        
        public void SetAutoButton(bool isOn)
        {
            _autoOnButton.gameObject.SetActive(isOn);
            _autoOffButton.gameObject.SetActive(!isOn);
        }
    }
}