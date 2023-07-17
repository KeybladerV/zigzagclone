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
    public sealed class MainScreenMediator : Mediator
    {
        [Inject] public MainScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }
        [Inject] public IScoreController ScoreController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(View, View.OnOverlayButtonClick, OnOverlayButton);
            EventMap.Map(View, View.OnSettingsButtonClick, OnSettingsButton);
            EventMap.Map(View, View.OnSkinsButtonClick, OnSkinsButton);
        }

        [Start]
        private void OnStart()
        {
            ToggleInputs(false);
            View.SetScoreData(ScoreController.Statistics);
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
        
        private void OnOverlayButton()
        {
            ScreensController.Show(Screen.GameScreen);
        }
        
        private void OnSettingsButton()
        {
            ScreensController.Show(Screen.SettingsScreen);
        }
        
        private void OnSkinsButton()
        {
            ScreensController.Show(Screen.SkinScreen);
        }
    }
}
