using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Components.Gem;
using Modules.Character;
using Modules.GameInput;
using Modules.Settings;
using Screen = Modules.Screens.Screen;

namespace Components.Character
{
    public sealed class CharacterMediator : Mediator
    {
        [Inject] public CharacterView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public ICharacterController CharacterController { get; set; }
        [Inject] public ISettingsController SettingsController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(ScreenEvent.Shown, OnScreenShown);
            EventMap.Map(ScreenEvent.Hidden, OnScreenHidden);
            EventMap.Map(GameInputEvent.OnAnyInput, OnAnyInput);
            EventMap.Map(CharacterEvents.ResetCharacter, ResetCharacter);
            EventMap.Map(CharacterEvents.SkinChanged, OnSkinChanged);
            
            EventMap.Map(View, View.CharacterEnteredPlatform, CharacterEnteredPlatform);
            EventMap.Map(View, View.CharacterFall, CharacterMustFall);
            EventMap.Map(View, View.CharacterCollectedGem, CharacterCollectedGem);
        }

        private void OnSkinChanged(int index)
        {
            View.SetSkin(CharacterController.GetSkins()[index].Color);
        }

        private void CharacterCollectedGem(GemView view)
        {
            EventMap.Dispatch(CharacterEvents.CharacterCollectedGem, view);
        }

        private void ResetCharacter()
        {
            View.DoReset();
        }

        private void CharacterEnteredPlatform()
        {
            EventMap.Dispatch(CharacterEvents.CharacterEnteredPlatform);
        }

        private void CharacterMustFall()
        {
            View.StopMovement();
            EventMap.Dispatch(CharacterEvents.CharacterFall);
            ScreensController.Show(Screen.GameOverScreen);
        }

        private void OnAnyInput()
        {
            View.ToggleDirection();
        }

        private void OnScreenShown(ScreenBase obj)
        {
            if (obj == Screen.PauseScreen)
                View.SetSleep(true);
            
            if (obj != Screen.GameScreen)
                return;

            View.SetSleep(false);

            View.StartMovement();
            if (SettingsController.Settings.AutoOn)
            {
                GameInputController.BlockInput(this);
                View.SetAuto(true);
            }
        }
        
        private void OnScreenHidden(ScreenBase obj)
        {
            if (obj != Screen.GameScreen)
                return;

            View.StopMovement();
            if (SettingsController.Settings.AutoOn)
            {
                GameInputController.UnblockInput(this);
                View.SetAuto(false);
            }
        }
        
        [OnDestroy]
        private void OnDestroy()
        {
            EventMap.UnmapAll();
        }
    }
}