using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Modules.GameInput;
using Modules.Score;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.Main
{
    public sealed class PauseScreenMediator : Mediator
    {
        [Inject] public PauseScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(View, View.OnContinueButtonClick, OnContinueButton);
            EventMap.Map(View, View.OnRestartButtonClick, OnRestartButton);
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
        
        private void OnContinueButton()
        {
            ScreensController.Show(Screen.GameScreen);
        }
        
        private void OnRestartButton()
        {
            ScreensController.Show(Screen.MainScreen);
        }
    }
}
