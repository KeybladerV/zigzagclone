using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Models.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Main
{
    [Mediator(typeof(PauseScreenMediator))]
    public sealed class PauseScreenView : UnityViewDispatcher
    {
        public readonly Event OnContinueButtonClick = new Event(typeof(PauseScreenView), nameof(OnContinueButtonClick));
        public readonly Event OnRestartButtonClick = new Event(typeof(PauseScreenView), nameof(OnRestartButtonClick));

        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;

        [Start]
        public void OnStart()
        {
            BindUnityEvent(_continueButton.onClick, OnContinueButtonClick);
            BindUnityEvent(_restartButton.onClick, OnRestartButtonClick);
        }

        [OnDestroy]
        private void OnDestroying()
        {
            UnbindAllUnityEvents();
        }
    }
}