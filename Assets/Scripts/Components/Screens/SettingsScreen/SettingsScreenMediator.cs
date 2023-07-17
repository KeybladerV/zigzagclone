using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Modules.GameInput;
using Modules.Settings;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.Main
{
    public sealed class SettingsScreenMediator : Mediator
    {
        [Inject] public SettingsScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }
        [Inject] public ISettingsController SettingsController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(View, View.OnCloseButtonClick, OnCloseButton);
            EventMap.Map(View, View.OnSoundButtonClick, OnSoundButton);
            EventMap.Map(View, View.OnAutoButtonClick, OnAutoButton);
            
            View.SetSoundButton(SettingsController.Settings.SoundOn);
            View.SetAutoButton(SettingsController.Settings.AutoOn);
        }

        private void OnAutoButton(bool isOn)
        {
            SettingsController.ChangeAuto(isOn);
            View.SetAutoButton(SettingsController.Settings.AutoOn);
        }

        private void OnSoundButton(bool isOn)
        {
            SettingsController.ChangeSound(isOn);
            View.SetSoundButton(SettingsController.Settings.SoundOn);
        }

        [Start]
        private void OnStart()
        {
            ToggleInputs(false);
        }

        [OnDestroy]
        private void OnDestroy()
        {
            EventMap.UnmapAll();
            ToggleInputs(true);
        }
        
        private void ToggleInputs(bool enable)
        {
            if(enable)
                GameInputController.UnblockInput(this);
            else
                GameInputController.BlockInput(this);
        }
        
        private void OnCloseButton()
        {
            ScreensController.Show(Screen.MainScreen);
        }
    }
}
