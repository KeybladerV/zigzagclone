using System;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Mediation;
using Build1.PostMVC.Unity.App.Mediation;
using Components.Gem;
using UnityEngine;
using Event = Build1.PostMVC.Core.MVCS.Events.Event;

namespace Components.Character
{
    [Mediator(typeof(CharacterMediator))]
    public sealed class CharacterView : UnityViewDispatcher
    {
        public readonly Event CharacterEnteredPlatform = new Event();
        public readonly Event CharacterFall = new Event();
        public readonly Event<GemView> CharacterCollectedGem = new Event<GemView>();
        
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _speed;
        [SerializeField] private Material _material;
        
        private bool _isAllowedToMove;
        private MovementDirection _movementDirection;
        
        private Collider _currentPlatformCollider;
        
        private Vector3 _startPosition;

        private bool _isAuto;
        private bool _isSleep;
        
        [Start]
        private void OnStart()
        {
            _startPosition = transform.position;
        }
        
        public void StartMovement()
        {
            _isAllowedToMove = true;
        }
        
        public void StopMovement()
        {
            _isAllowedToMove = false;
        }
        
        public void ToggleDirection()
        {
            _movementDirection = _movementDirection.GetOpposite();
        }

        public void DoReset()
        {
            transform.position = _startPosition;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            _rigidbody.isKinematic = false;
        }

        private void FixedUpdate()
        {
            if (_isSleep)
            {
                _rigidbody.Sleep();
                return;
            }
            if(_isAllowedToMove)
                _rigidbody.velocity = _movementDirection.GetVector3() * _speed;
            if (_isAuto)
            {
                var rayPos = transform.position + Vector3.up * 5;
                var rayDir = (transform.position + _movementDirection.GetVector3()) - rayPos;
                if(!Physics.Raycast(rayPos, rayDir, 10f))
                    ToggleDirection();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var platformView = other.GetComponent<Platform.PlatformView>();
            if (platformView != null)
            {
                _currentPlatformCollider = other;
                Dispatch(CharacterEnteredPlatform);
                return;
            }
            
            var gemView = other.GetComponent<GemView>();
            if (gemView != null)
            {
                Dispatch(CharacterCollectedGem, gemView);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Component otherView = other.GetComponent<Platform.PlatformView>();
            if(otherView != null)
                if(other == _currentPlatformCollider)
                    Dispatch(CharacterFall);
        }

        public void SetSkin(Color color)
        {
            _material.color = color;
        }

        public void SetAuto(bool isAuto)
        {
            _isAuto = isAuto;
        }

        public void SetSleep(bool isSleep)
        {
            _isSleep = isSleep;
        }
    }
}
