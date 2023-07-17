using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using DG.Tweening;
using UnityEngine;

namespace Components.Screens.Main.Camera
{
    [Mediator(typeof(CameraMediator))]
    public sealed class CameraView : UnityViewDispatcher
    {
        [SerializeField] private UnityEngine.Camera gameCamera;
        [SerializeField] private Vector3 _offset;

        private Tweener _tweenMove;

        private Transform _lockOnTarget;

        [OnDisable]
        public void OnDisabled()
        {
            StopMove();
        }

        private void LateUpdate()
        {
            if (_lockOnTarget != null)
                if(!(_tweenMove is { active: true }))
                    transform.position = _lockOnTarget.position + _offset;
        }

        /*
         * Move.
         */

        public void MoveTo(Vector2 position, float timeToMove, Ease ease)
        {
            var position3 = new Vector3(position.x, gameCamera.transform.position.y, position.y);

            if (timeToMove <= 0)
            {
                gameCamera.transform.position = position3;

                StopMove();
                Dispatch(CameraEvents.OnMoveComplete);
                return;
            }

            _tweenMove = gameCamera.transform.DOMove(position3, timeToMove)
                .SetEase(ease)
                .OnUpdate(() =>
                {
                    Dispatch(CameraEvents.OnPositionChangeByTween, _tweenMove.ElapsedPercentage());
                })
                .OnComplete(() =>
                {
                    Dispatch(CameraEvents.OnMoveComplete);
                });
        }

        private void StopMove()
        {
            if (_tweenMove?.active != true)
                return;
            _tweenMove.Kill();
            _tweenMove = null;
        }

        public void SetTargetToFollow(Transform target)
        {
            _lockOnTarget = target;
        }
        
        public void ClearTarget()
        {
            _lockOnTarget = null;
        }
    }
}