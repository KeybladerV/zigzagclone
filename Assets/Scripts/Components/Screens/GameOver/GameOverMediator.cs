using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Modules.GameInput;
using Modules.Score;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.GameOver
{
    public sealed class GameOverMediator : Mediator
    {
        [Inject] public GameOverScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }
        [Inject] public IScoreController ScoreController { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }
        
        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(View, View.RestartButtonClicked, RestartButtonClicked);
            
            SetData();
            ToggleInputs(false);
        }
        
        [OnDestroy]
        private void OnDestroying()
        {
            EventMap.UnmapAll();
            ToggleInputs(true);
        }

        private void RestartButtonClicked()
        {
            ScreensController.Show(Screen.MainScreen);
        }

        private void SetData()
        {
            View.SetData(ScoreController.Statistics);
        }
        
        private void ToggleInputs(bool enable)
        {
            if(enable)
                GameInputController.UnblockInput(this);
            else
                GameInputController.BlockInput(this);
        }
    }
}