using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Components.Screens.Game;
using Models.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.GameOver
{
    [Mediator(typeof(GameOverMediator))]
    public sealed class GameOverScreenView : UnityViewDispatcher
    {
        public readonly Event RestartButtonClicked = new Event(typeof(GameOverScreenView), nameof(RestartButtonClicked));
        
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _bestScoreText;
        
        [PostConstruct]
        public void PostConstruct()
        {
            BindUnityEvent(_restartButton.onClick, RestartButtonClicked);
        }
        
        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }

        public void SetData(IReadOnlyStatistics stats)
        {
            _scoreText.text = stats.Score.ToString();
            _bestScoreText.text = stats.BestScore.ToString();
        }
    }
}