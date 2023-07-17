using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Components.Character;
using Components.Gem;
using Components.Screens.Main;
using Modules.Settings;

namespace Components.Sounds
{
    public enum SoundType
    {
        CharGemPickup,
        CharNewPlatform,
        CharFall,
        ScreenShow,
    }
    
    public sealed class SoundsMediator : Mediator
    {
        [Inject] public SoundsView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public ISettingsController SettingsController { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(CharacterEvents.CharacterCollectedGem, OnCharacterCollectedGem);
            EventMap.Map(CharacterEvents.CharacterEnteredPlatform, OnCharacterEnteredPlatform);
            EventMap.Map(CharacterEvents.CharacterFall, OnCharacterFall);
            
            EventMap.Map(ScreenEvent.Shown, OnScreenShown);
            
            EventMap.Map(SettingsEvents.OnSoundSettingsChanged, OnSoundSettingsChanged);
            
            View.SetSound(SettingsController.Settings.SoundOn);
        }

        private void OnSoundSettingsChanged(bool isOn)
        {
            View.SetSound(isOn);
        }

        private void OnScreenShown(ScreenBase obj)
        {
            View.PlaySound(SoundType.ScreenShow);
        }

        private void OnCharacterFall()
        {
            View.PlaySound(SoundType.CharFall);
        }

        private void OnCharacterEnteredPlatform()
        {
            View.PlaySound(SoundType.CharNewPlatform);
        }

        [OnDestroy]
        private void OnDestroy()
        {
            EventMap.UnmapAll();
        }

        private void OnCharacterCollectedGem(GemView obj)
        {
            View.PlaySound(SoundType.CharGemPickup);
        }
    }
}