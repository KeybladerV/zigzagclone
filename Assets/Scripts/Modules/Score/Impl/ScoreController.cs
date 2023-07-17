using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using Components.Character;
using Components.Gem;
using Models.Stats;
using Modules.Repository;
using Screen = Modules.Screens.Screen;

namespace Modules.Score.Impl
{
    public sealed class ScoreController : IScoreController
    {
        private const string FileName = "stats.json";
        
        [Inject] public IEventDispatcher Dispatcher { get; set; }
        [Inject] public IRepositoryController RepositoryController { get; set; }
        
        private Statistics _statistics;
        
        public IReadOnlyStatistics Statistics => _statistics;

        [PostConstruct]
        private void PostConstruct()
        {
            _statistics = RepositoryController.LoadOrCreate<Statistics>(FileName, out var created);
            Dispatcher.AddListener(CharacterEvents.CharacterEnteredPlatform, OnCharacterEnteredPlatform);
            Dispatcher.AddListener(CharacterEvents.CharacterCollectedGem, OnCharacterCollectedGem);
            Dispatcher.AddListener(ScreenEvent.Shown, OnScreenShown);
        }

        private void OnCharacterCollectedGem(GemView obj)
        {
            _statistics.Gems++;
            Dispatcher.Dispatch(ScoreEvents.ScoreUpdated, _statistics);
        }

        [OnDestroy]
        private void OnDestroying()
        {
            Dispatcher.RemoveListener(CharacterEvents.CharacterEnteredPlatform, OnCharacterEnteredPlatform);
            Dispatcher.RemoveListener(ScreenEvent.Shown, OnScreenShown);
            RepositoryController.Save(_statistics, FileName);
        }
        
        public bool WithdrawGems(int amount)
        {
            if (_statistics.Gems < amount)
                return false;
            _statistics.Gems -= amount;
            Dispatcher.Dispatch(ScoreEvents.ScoreUpdated, _statistics);
            return true;
        }

        private void OnScreenShown(ScreenBase obj)
        {
            if (obj == Screen.GameScreen)
            {
                _statistics.Score = 0;
                _statistics.GamesPlayed++;
                Dispatcher.Dispatch(ScoreEvents.ScoreUpdated, _statistics);
            }
        }

        private void OnCharacterEnteredPlatform()
        {
            _statistics.Score++;
            if (_statistics.Score > _statistics.BestScore)
                _statistics.BestScore = _statistics.Score;
            Dispatcher.Dispatch(ScoreEvents.ScoreUpdated, _statistics);
        }
        
        
    }
}