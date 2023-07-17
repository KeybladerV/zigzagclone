using Build1.PostMVC.Core.MVCS.Events;
using DG.Tweening;
using UnityEngine;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Screens.Main.Camera
{
    public static class CameraEvents
    {
        public static readonly Event                 OnPositionChange        = new Event(typeof(CameraEvents), nameof(OnPositionChange));
        public static readonly Event<float>          OnPositionChangeByTween = new Event<float>(typeof(CameraEvents), nameof(OnPositionChangeByTween));
        public static readonly Event                 OnZoomComplete          = new Event(typeof(CameraEvents), nameof(OnZoomComplete));
        public static readonly Event                 OnMoveComplete          = new Event(typeof(CameraEvents), nameof(OnMoveComplete));
        public static readonly Event<Vector2, float, Ease> CameraMoveTo            = new Event<Vector2, float, Ease>(typeof(CameraEvents), nameof(CameraMoveTo));
    }
}