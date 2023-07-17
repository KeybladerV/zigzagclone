using UnityEngine;
using UnityEngine.UI;

namespace Build1.PostMVC.Unity.App.Modules.FullScreen.Components
{
    [DisallowMultipleComponent]
    public sealed class FullScreenButton : Button
    {
        private IFullScreenController _controller;
        private bool                  _togglingFullScreen;

        protected override void Awake()
        {
            base.Awake();

            onClick.AddListener(OnClick);
        }

        protected override void OnDestroy()
        {
            onClick.RemoveListener(OnClick);

            base.OnDestroy();
        }

        private void OnClick()
        {
            _controller ??= Core.PostMVC.GetInstance<IFullScreenController>();

            #if UNITY_WEBGL && !UNITY_EDITOR

            if (_controller.IsInFullScreen && !_togglingFullScreen)
                _controller.ToggleFullScreen();
            
            _togglingFullScreen = false;

            #else

            _controller.ToggleFullScreen();

            #endif
        }

        #if UNITY_WEBGL && !UNITY_EDITOR
        
        public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
 
            if (eventData.button != UnityEngine.EventSystems.PointerEventData.InputButton.Left)
                return;

            _controller ??= Core.PostMVC.GetInstance<IFullScreenController>();

            if (!_controller.IsInFullScreen) 
            {
                _togglingFullScreen = true;
                _controller.ToggleFullScreen();
            }
        }

        #endif
    }
}