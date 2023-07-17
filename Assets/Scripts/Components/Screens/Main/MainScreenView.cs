using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Models.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Main
{
    [Mediator(typeof(MainScreenMediator))]
    public sealed class MainScreenView : UnityViewDispatcher
    {
        public readonly Event OnOverlayButtonClick = new Event(typeof(MainScreenView), nameof(OnOverlayButtonClick));
        public readonly Event OnSettingsButtonClick = new Event(typeof(MainScreenView), nameof(OnSettingsButtonClick));
        public readonly Event OnSkinsButtonClick = new Event(typeof(MainScreenView), nameof(OnSkinsButtonClick));

        [SerializeField] private Button _overlayButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _skinsButton;

        [SerializeField] private TMP_Text _gemsText;
        [SerializeField] private TMP_Text _highScoreText;
        [SerializeField] private TMP_Text _gamesPlayedText;

        [Start]
        public void OnStart()
        {
            BindUnityEvent(_overlayButton.onClick, OnOverlayButtonClick);
            BindUnityEvent(_settingsButton.onClick, OnSettingsButtonClick);
            BindUnityEvent(_skinsButton.onClick, OnSkinsButtonClick);
        }

        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }

        public void SetScoreData(IReadOnlyStatistics statistics)
        {
            _gemsText.text = statistics.Gems.ToString();
            _highScoreText.text = $"Best Score: {statistics.BestScore.ToString()}";
            _gamesPlayedText.text = $"Games Played: {statistics.GamesPlayed.ToString()}";
        }
    }
}