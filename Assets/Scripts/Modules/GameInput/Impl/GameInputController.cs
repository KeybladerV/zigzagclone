using System;
using System.Collections.Generic;
using Build1.PostMVC.Core.MVCS.Events;
using Build1.PostMVC.Core.MVCS.Injection;
using Build1.PostMVC.Unity.App.Mediation;
using Build1.PostMVC.Unity.App.Modules.UI.Screens;
using UnityEngine.InputSystem;
using Screen = Modules.Screens.Screen;

namespace Modules.GameInput.Impl
{
    public sealed class GameInputController : IGameInputController
    {
        [Inject] public IEventDispatcher Dispatcher { get; set; }

        private readonly HashSet<object> _inputBlockers = new HashSet<object>();

        private DefaultControl _defaultControls;

        [PostConstruct]
        private void PostConstruct()
        {
            _defaultControls = new DefaultControl();
            _defaultControls.Disable();
            _defaultControls.Default.any.performed += OnAnyPerformed;
        }

        [OnDestroy]
        private void OnDestroy()
        {
            _defaultControls.Default.any.performed -= OnAnyPerformed;
        }

        private void OnAnyPerformed(InputAction.CallbackContext obj)
        {
            Dispatcher.Dispatch(GameInputEvent.OnAnyInput);
        }

        /*
         * Public.
         */

        public void BlockInput(object blocker)
        {
            _inputBlockers.Add(blocker);

            ValidateControlsState();
        }

        public void UnblockInput(object blocker)
        {
            _inputBlockers.Remove(blocker);
            
            ValidateControlsState();
        }
        
        private void ValidateControlsState()
        {
            if(_inputBlockers.Count == 0)
                _defaultControls.Enable();
            else
                _defaultControls.Disable();
        }
    }
}