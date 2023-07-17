using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Models.Stats;
using Modules.Score;
using Modules.Score.Impl;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.Game
{
    public sealed class GameScreenMediator : Mediator
    {
        [Inject] public GameScreenView View { get; set; }
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IScoreController ScoreController { get; set; }
        [Inject] public IScreensController ScreensController { get; set; }

        [PostConstruct]
        public void PostConstruct()
        {
            EventMap.Map(ScoreEvents.ScoreUpdated, OnScoreUpdated);
            EventMap.Map(View, View.OnPauseButtonClicked, OnPauseButtonClicked);
            
            View.SetScoreData(ScoreController.Statistics);
        }

        private void OnPauseButtonClicked()
        {
            ScreensController.Show(Screen.PauseScreen);
        }

        private void OnScoreUpdated(IReadOnlyStatistics data)
        {
            View.SetScoreData(data);
        }

        [OnDestroy]
        private void OnDestroy()
        {
            EventMap.UnmapAll();
        }
    }
}
