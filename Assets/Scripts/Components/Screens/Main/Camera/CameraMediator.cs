using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Events;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using DG.Tweening;
using Modules.Character;
using UnityEngine;
using Screen = Modules.Screens.Screen;

namespace Components.Screens.Main.Camera
{
    public sealed class CameraMediator : Mediator
    {
        [Inject] public CameraView            View                 { get; set; }
        [Inject] public IEventMap             EventMap             { get; set; }
        [Inject] public ICharacterController CharacterController { get; set; }

        [Awake]
        public void OnAwake()
        {
            EventMap.Map(View, CameraEvents.OnPositionChangeByTween, OnCameraPositionChangeByTween);
            EventMap.Map(CameraEvents.CameraMoveTo, OnCameraMoveToEvent);
            EventMap.Map(View,CameraEvents.OnMoveComplete, OnCameraMoveComplete);
            
            EventMap.Map(ScreenEvent.Shown, OnScreenShown);
        }

        private void OnScreenShown(ScreenBase obj)
        {
            if (obj != Screen.GameScreen && obj != Screen.MainScreen)
                View.ClearTarget();
            else
                View.SetTargetToFollow(CharacterController.CharacterTransform);
        }

        [OnDestroy]
        public void OnDestroy()
        {
            EventMap.UnmapAll();
        }

        /*
         * Event Handlers.
         */
        
        private void OnCameraMoveToEvent(Vector2 position, float time, Ease ease)
        {
            View.MoveTo(position, time, ease);
        }

        private void OnCameraMoveComplete()
        {
            EventMap.Dispatch(CameraEvents.OnMoveComplete);
        }

        private void OnCameraPositionChangeByTween(float percentage)
        {
            EventMap.Dispatch(CameraEvents.OnPositionChangeByTween, percentage);
        }
    }
}