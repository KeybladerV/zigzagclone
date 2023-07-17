#if UNITY_ANDROID || UNITY_EDITOR

using System;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.Android.Impl
{
    internal sealed class AndroidAgent : MonoBehaviour
    {
        internal event Action OnBack;

        #if ENABLE_INPUT_SYSTEM
        
        private Build1.PostMVC.UnityApp.Modules.Android.Impl.InputActions _actions;
        
        private void Awake()
        {
            _actions = new Build1.PostMVC.UnityApp.Modules.Android.Impl.InputActions();
            _actions.Enable();
        }

        private void OnDestroy()
        {
            _actions.Disable();
            _actions = null;
        }
        
        private void Update()
        {
            if (_actions.AndroidBackButton.Esc.WasReleasedThisFrame())
                OnBack?.Invoke();    
        }
        
        #else
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnBack?.Invoke();
        }
        
        #endif
    }
}

#endif