using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.Logging;
using Modules.GameInput;
using UnityEngine;

namespace Components.Screens.LoadingScreen
{
    public sealed class LoadingScreenMediator : Mediator
    {
        [Log(LogLevel.Warning)] public ILog Log { get; set; }
        
        [Inject] public IEventMap EventMap { get; set; }
        [Inject] public IGameInputController GameInputController { get; set; }

        [OnEnable]
        public void OnStart()
        {
            EventMap.Map(LoadingScreenEvent.Complete, OnComplete);
            ToggleInputs(false);
        }

        [OnDisable]
        public void OnDisable()
        {
            ToggleInputs(true);
        }

        [OnDestroy]
        public void OnDestroy()
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

        private void OnComplete()
        {
            EventMap.Dispatch(LoadingScreenEvent.Completed);
        }
    }
}