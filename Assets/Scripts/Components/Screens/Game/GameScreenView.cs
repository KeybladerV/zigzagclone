using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Models.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Game
{
    [Mediator(typeof(GameScreenMediator))]
    public sealed class GameScreenView : UnityViewDispatcher
    {
        public readonly Event OnPauseButtonClicked = new Event();
        
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _gemsText;

        [Start]
        public void OnStart()
        {
            BindUnityEvent(_pauseButton.onClick, OnPauseButtonClicked);
        }
        
        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }

        public void SetScoreData(IReadOnlyStatistics stats)
        {
            _scoreText.text = stats.Score.ToString();
            _gemsText.text = stats.Gems.ToString();
        }
    }
}