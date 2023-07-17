using System;
using Build1.PostMVC.Core.MVCS.Injection;
using UnityEngine;

namespace Build1.PostMVC.Unity.App.Modules.App.Impl
{
    public sealed class AppAgent : MonoBehaviour
    {
        public event Action<bool> Pause;
        public event Action<bool> Focus;
        public event Action       Quitting;
        
        [PostConstruct]
        public void PostConstruct()
        {
            #if UNITY_EDITOR
            
            // Some docs say double firing is possible if run in background is set to true.
            // We manage it in the controller using a flag.
            UnityEditor.EditorApplication.pauseStateChanged += OnEditorPause;
            
            #endif
            
            Application.focusChanged += OnFocusChanged;
            Application.quitting += OnQuitting;
        }

        [PreDestroy]
        public void PreDestroy()
        {
            #if UNITY_EDITOR
            
            UnityEditor.EditorApplication.pauseStateChanged -= OnEditorPause;
            
            #endif
            
            Application.focusChanged -= OnFocusChanged;
            Application.quitting -= OnQuitting;
        }

        /*
         * Mono Behavior.
         */

        private void OnApplicationPause(bool pauseStatus)
        {
            Pause?.Invoke(pauseStatus);
        }
        
        private void OnFocusChanged(bool focused)
        {
            Focus?.Invoke(focused);
        }
        
        private void OnQuitting()
        {
            Quitting?.Invoke();
        }
        
        #if UNITY_EDITOR
        
        private void OnEditorPause(UnityEditor.PauseState state)
        {
            Pause?.Invoke(state == UnityEditor.PauseState.Paused);
        }
        
        #endif
    }
}