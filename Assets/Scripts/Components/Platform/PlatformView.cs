using Build1.PostMVC.Unity.App.Mediation;
using Components.Gem;
using Models.Platform;
using UnityEngine;

namespace Components.Platform
{
    public sealed class PlatformView : UnityViewDispatcher
    {
        [SerializeField] private GemView _gem;
        
        public PlatformModel Model { get; private set; }
        public GemView Gem => _gem;
        
        private Transform _transform;
        private Rigidbody _rigidbody;
        
        [Awake]
        private void OnAwake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void SetModel(PlatformModel model)
        {
            Model = model;
        }
        
        public void UpdateByModel()
        {
            _transform.localScale = Model.Scale;
            _transform.position = Model.Position;   
        }

        public void SetKinematic(bool isKinematic)
        {
            _rigidbody.isKinematic = isKinematic;
        }
        
        public void SetGemActive(bool isActive)
        {
            _gem.gameObject.SetActive(isActive);
        }
    }
}